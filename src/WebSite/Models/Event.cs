using System.Text.Json.Serialization;

namespace NNUG.WebSite.Models
{
    public class Event
    {
        public string Name { get; set; }

        /// <summary>Local start time at the event's location.</summary>
        public DateTime StartTime
        {
            get
            {
                var localTime = DateTimeOffset.FromUnixTimeMilliseconds(Time).UtcDateTime.AddMilliseconds(UtcOffset);
                return DateTime.SpecifyKind(localTime, DateTimeKind.Unspecified);
            }
        }

        public long Time { get; set; }
        public long UtcOffset { get; set; }

        [JsonPropertyName("link")]
        public string EventUrl { get; set; }
        public Venue Venue { get; set; }
    }
}
