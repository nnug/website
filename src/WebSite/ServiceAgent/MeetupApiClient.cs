using System.Collections.Generic;
using System.Threading.Tasks;
using NNUG.WebSite.Integration;
using NNUG.WebSite.Models;

namespace NNUG.WebSite.ServiceAgent
{
    public class MeetupApiClient : IMeetupApiClient
    {
        public MeetupApiClient() : this(new MeetupSettings(), new HttpGetStringCommand())
        {
        }

        public MeetupApiClient(IMeetupSettings meetupSettings, IHttpGetStringCommand httpGetStringCommand)
        {
            _meetupSettings = meetupSettings;
            _httpGetStringCommand = httpGetStringCommand;
        }

        private IMeetupSettings _meetupSettings;
        private IHttpGetStringCommand _httpGetStringCommand;

        public async Task<IEnumerable<Event>> GetEvents(string meetupGroupName)
        {
            var response = await _httpGetStringCommand.Invoke(_meetupSettings.GetSignedEventUri(meetupGroupName));
            return new Event[0];
        }
    }
}