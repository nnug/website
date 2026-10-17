# Downloads upcoming events for each chapter in _data/chapters.yml from the
# group's public Meetup iCal feed and writes them to _data/events/<meetup>.json.
#
# Run before `jekyll build`. A chapter whose feed can't be fetched gets no
# file, and its tile falls back to a plain link to Meetup.
#
#   ruby _scripts/fetch_meetup_events.rb

require "json"
require "net/http"
require "time"
require "uri"
require "yaml"

ENV["TZ"] = "Europe/Oslo" # Show times as local Norwegian time.

ROOT = File.expand_path("..", __dir__)
OUTPUT_DIR = File.join(ROOT, "_data", "events")
MAX_EVENTS = 5

def fetch(url, redirects = 3)
  uri = URI(url)
  response = Net::HTTP.start(uri.host, uri.port, use_ssl: uri.scheme == "https",
                             open_timeout: 10, read_timeout: 20) do |http|
    http.get(uri.request_uri, "User-Agent" => "nnug.no event import (+https://www.nnug.no)")
  end
  case response
  when Net::HTTPSuccess then response.body.b
  when Net::HTTPRedirection
    raise "too many redirects" if redirects.zero?
    fetch(URI.join(url, response["location"]).to_s, redirects - 1)
  else raise "HTTP #{response.code}"
  end
end

# Returns one hash per VEVENT, mapping property name to [params, value].
def parse_ical(bytes)
  # Unfold continuation lines before decoding: a fold can split a multibyte character.
  text = bytes.b.gsub("\r\n".b, "\n".b).gsub(/\n[ \t]/n, "".b).force_encoding("UTF-8").scrub
  lines = text.split("\n")
  events = []
  current = nil
  lines.each do |line|
    case line
    when "BEGIN:VEVENT" then current = {}
    when "END:VEVENT"
      events << current if current
      current = nil
    else
      next unless current
      key, value = line.split(":", 2)
      next unless value
      name, *params = key.split(";")
      current[name] ||= [params, value]
    end
  end
  events
end

def unescape(text)
  text.gsub(/\\([\\;,nN])/) { %w[n N].include?($1) ? " " : $1 }.strip
end

def parse_start(value)
  m = value.match(/\A(\d{4})(\d{2})(\d{2})(?:T(\d{2})(\d{2})(\d{2})(Z)?)?/) or raise "bad DTSTART #{value}"
  parts = m.captures.first(6).map(&:to_i)
  # UTC times end in Z; TZID=Europe/Oslo and floating times are already local.
  m[7] ? Time.utc(*parts).getlocal : Time.local(*parts)
end

def event_hash(vevent)
  start = parse_start(vevent.dig("DTSTART", 1))
  {
    "name" => unescape(vevent.dig("SUMMARY", 1).to_s),
    "start" => start.iso8601,
    "year" => start.year,
    "month" => start.month,
    "day" => start.day,
    "time" => start.strftime("%H:%M"),
    "venue" => (venue = unescape(vevent.dig("LOCATION", 1).to_s)).empty? ? nil : venue.split(" (").first,
    "url" => vevent.dig("URL", 1)
  }
end

chapters = YAML.safe_load(File.read(File.join(ROOT, "_data", "chapters.yml")))
Dir.mkdir(OUTPUT_DIR) unless Dir.exist?(OUTPUT_DIR)
now = Time.now

chapters.each do |chapter|
  group = chapter["meetup"]
  path = File.join(OUTPUT_DIR, "#{group}.json")
  begin
    feed = fetch("https://www.meetup.com/#{group}/events/ical/")
    raise "not an iCal feed" unless feed.include?("BEGIN:VCALENDAR".b)

    events = parse_ical(feed)
             .select { |e| e["DTSTART"] && e["SUMMARY"] }
             .map { |e| event_hash(e) }
             .select { |e| Time.iso8601(e["start"]) >= now - 3 * 3600 } # Keep events that started recently.
             .sort_by { |e| e["start"] }
             .first(MAX_EVENTS)

    File.write(path, JSON.pretty_generate(events) + "\n")
    puts "#{group}: #{events.size} upcoming event(s)"
  rescue StandardError => e
    File.delete(path) if File.exist?(path)
    warn "#{group}: could not import events (#{e.message})"
  end
end
