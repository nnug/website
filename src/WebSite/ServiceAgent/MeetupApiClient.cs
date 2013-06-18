using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NNUG.WebSite.Integration;
using NNUG.WebSite.Models;
using Newtonsoft.Json.Linq;

namespace NNUG.WebSite.ServiceAgent
{
    public class MeetupApiClient : IMeetupApiClient
    {
        public static readonly Uri BaseUri = new Uri("http://www.meetup.com");

        public MeetupApiClient() : this(new MeetupSettings(), new HttpGetStringCommand())
        {
        }

        public MeetupApiClient(IMeetupSettings meetupSettings, IHttpGetStringCommand httpGetStringCommand)
        {
            _meetupSettings = meetupSettings;
            _httpGetStringCommand = httpGetStringCommand;
        }

        private readonly IMeetupSettings _meetupSettings;
        private readonly IHttpGetStringCommand _httpGetStringCommand;

        public async Task<ICollection<Event>> GetEvents(string meetupGroupName)
        {
            var events = new List<Event>();

            var response = await _httpGetStringCommand.Invoke(_meetupSettings.GetSignedEventUri(meetupGroupName));
            var jObject = JObject.Parse(response);
            foreach (JObject meetupEvent in jObject["results"])
            {
                var venueJson = (JObject)meetupEvent["venue"];

                var me = new Event
                    {
                        Name = meetupEvent.FirstOrDefault<string>("name"),
                        Description = meetupEvent.FirstOrDefault<string>("description"),
                        EventUrl = meetupEvent.FirstOrDefault<string>("event_url"),
                        RsvpLimit = meetupEvent.FirstOrDefault<int>("rsvp_limit"),
                        StartTime = meetupEvent.FirstOrDefault("time"),
                        WaitListCount = meetupEvent.FirstOrDefault<int>("waitlist_count"),
                        YesRsvpCount = meetupEvent.FirstOrDefault<int>("yes_rsvp_count"),
                        Venue = new Venue
                            {
                                Name = venueJson.FirstOrDefault<string>("name"),
                                Address = venueJson.FirstOrDefault<string>("address_1"),
                                City = venueJson.FirstOrDefault<string>("city"),
                                Country = venueJson.FirstOrDefault<string>("country")
                            }
                    };

                events.Add(me);
            }

            
            return events;
        }


    }
}