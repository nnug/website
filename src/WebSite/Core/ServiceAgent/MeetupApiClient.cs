using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NNUG.WebSite.Core.Integration;
using NNUG.WebSite.Models;
using ServiceStack.Text;

namespace NNUG.WebSite.Core.ServiceAgent
{
    public class MeetupApiClient : IMeetupApiClient
    {
        public static readonly Uri BaseUri = new Uri("http://www.meetup.com");
        private readonly IMeetupSettings _meetupSettings;
        private readonly IHttpGetStringCommand _httpGetStringCommand;

        static MeetupApiClient()
        {
            JsConfig.PropertyConvention = JsonPropertyConvention.Lenient;
        }

        public MeetupApiClient(IMeetupSettings meetupSettings, IHttpGetStringCommand httpGetStringCommand)
        {
            _meetupSettings = meetupSettings;
            _httpGetStringCommand = httpGetStringCommand;
        }

        public async Task<ICollection<Event>> GetEvents(string meetupGroupUrl)
        {
            return await GetMeetupResults<Event>(_meetupSettings.GetSignedEventUri(meetupGroupUrl));
        }

        public async Task<MeetupGroup> GetGroupInformation(string meetupGroupUrl)
        {
            var results = await GetMeetupResults<MeetupGroup>(_meetupSettings.GetSignedGroupUri(meetupGroupUrl));
            return results.First();
        }

        private async Task<ICollection<T>> GetMeetupResults<T>(Uri requestUri)
        {
            var response = await _httpGetStringCommand.InvokeAsync(requestUri);
            var meetupResponse = response.FromJson<MeetupResponse<T>>();
            return meetupResponse.Results;
        }
    }
}