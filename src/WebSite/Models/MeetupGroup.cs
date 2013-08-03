using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using NNUG.WebSite.Core.Integration;
using NNUG.WebSite.Core.ServiceAgent;

namespace NNUG.WebSite.Models
{
    public class MeetupGroup
    {
        private readonly IMeetupSettings _meetupSettings;
        private readonly IHttpGetStringCommand _httpGetStringCommand;
        private readonly string _meetupGroupUrl;

        public MeetupGroup(IMeetupSettings meetupSettings, IHttpGetStringCommand httpGetStringCommand, string meetupGroupUrl)
        {
            _meetupSettings = meetupSettings;
            _httpGetStringCommand = httpGetStringCommand;
            _meetupGroupUrl = meetupGroupUrl;
        }

        public async Task<MeetupGroup> LoadFromMeetupAsync()
        {
            var meetupApiClient = new MeetupApiClient(_meetupSettings, _httpGetStringCommand);
            try
            {
                var groupInformation = await meetupApiClient.GetGroupInformation(_meetupGroupUrl);
                groupInformation.UpcomingEvents = await meetupApiClient.GetEvents(_meetupGroupUrl);

                return groupInformation;
            }
            catch (HttpRequestException e)
            {
                return null;
            }
        }

        public string Name { get; private set; }

        public int Members { get; set; }

        public double Rating { get; set; }


        public IEnumerable<Event> UpcomingEvents { get; private set; }
    }
}