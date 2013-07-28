using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NNUG.WebSite.Integration;
using NNUG.WebSite.Models;
using ServiceStack.Text;

namespace NNUG.WebSite.ServiceAgent
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

        public MeetupApiClient() : this(new MeetupSettings(), new HttpGetStringCommand())
        {
        }

        public MeetupApiClient(IMeetupSettings meetupSettings, IHttpGetStringCommand httpGetStringCommand)
        {
            _meetupSettings = meetupSettings;
            _httpGetStringCommand = httpGetStringCommand;
        }

        public async Task<ICollection<Event>> GetEvents(string meetupGroupName)
        {
            return await GetMeetupResults<Event>(_meetupSettings.GetSignedEventUri(meetupGroupName));
        }

        private async Task<ICollection<T>> GetMeetupResults<T>(Uri requestUri)
        {
            var response = await _httpGetStringCommand.Invoke(requestUri);
            var meetupResponse = response.FromJson<MeetupResponse<T>>();
            return meetupResponse.Results;
        }
    }
}