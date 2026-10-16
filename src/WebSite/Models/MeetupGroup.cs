using System.Text.Json;
using NNUG.WebSite.Core.Integration;
using NNUG.WebSite.Core.ServiceAgent;

namespace NNUG.WebSite.Models
{
    public class MeetupGroup
    {
        private readonly IHttpGetStringCommand _httpGetStringCommand;
        private readonly string _meetupGroupUrl;

        // Used by the JSON deserializer.
        public MeetupGroup()
        {
        }

        public MeetupGroup(IHttpGetStringCommand httpGetStringCommand, string meetupGroupUrl)
        {
            _httpGetStringCommand = httpGetStringCommand;
            _meetupGroupUrl = meetupGroupUrl;
        }

        public async Task<MeetupGroup> LoadFromMeetupAsync()
        {
            var meetupApiClient = new MeetupApiClient(_httpGetStringCommand);
            try
            {
                var groupInformation = await meetupApiClient.GetGroupInformation(_meetupGroupUrl);
                groupInformation.UpcomingEvents = await meetupApiClient.GetEvents(_meetupGroupUrl);

                return groupInformation;
            }
            catch (Exception ex) when (ex is HttpRequestException or JsonException)
            {
                return null;
            }
        }

        public string Name { get; set; }

        public int Members { get; set; }

        public IEnumerable<Event> UpcomingEvents { get; private set; }
    }
}
