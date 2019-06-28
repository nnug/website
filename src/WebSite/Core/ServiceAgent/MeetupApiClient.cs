using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NNUG.WebSite.Core.Integration;
using NNUG.WebSite.Models;
using ServiceStack;
using ServiceStack.Text;

namespace NNUG.WebSite.Core.ServiceAgent
{
    public class MeetupApiClient : IMeetupApiClient
    {
        public static readonly Uri BaseUri = new Uri("http://www.meetup.com");
        private readonly IHttpGetStringCommand _httpGetStringCommand;

        static MeetupApiClient()
        {
            JsConfig.PropertyConvention = PropertyConvention.Lenient;
        }

        public MeetupApiClient(IHttpGetStringCommand httpGetStringCommand)
        {
            _httpGetStringCommand = httpGetStringCommand;
        }

        public static Uri GetGroupUri(string meetupGroupUrl)
        {
            return new Uri($"https://api.meetup.com/{meetupGroupUrl}?&sign=true&photo-host=public&only=name,members");
        }

        public static Uri GetEventsUri(string meetupGroupUrl)
        {
            return new Uri($"https://api.meetup.com/{meetupGroupUrl}/events?&sign=true&photo-host=public&page=20&only=name,time,utc_offset,venue.name,link");
        }

        public async Task<MeetupGroup> GetGroupInformation(string meetupGroupUrl)
        {
            return await GetJson<MeetupGroup>(GetGroupUri(meetupGroupUrl));
        }

        public async Task<ICollection<Event>> GetEvents(string meetupGroupUrl)
        {
            return await GetJson<ICollection<Event>>(GetEventsUri(meetupGroupUrl));
        }

        private async Task<T> GetJson<T>(Uri requestUri)
        {
            var response = await _httpGetStringCommand.InvokeAsync(requestUri);
            return response.FromJson<T>();
        }
    }
}