using System.Threading.Tasks;
using NNUG.WebSite.Core.Integration;
using NNUG.WebSite.Core.ServiceAgent;

namespace NNUG.WebSite.Models
{
    public class Chapter
    {
        private readonly IMeetupSettings _meetupSettings;
        private readonly IHttpGetStringCommand _httpGetStringCommand;
        private string _meetupGroupUrl;
        private readonly string _twitterName;

        public Chapter(IMeetupSettings meetupSettings, IHttpGetStringCommand httpGetStringCommand, string meetupGroupUrl, string twitterName)
        {
            _meetupSettings = meetupSettings;
            _httpGetStringCommand = httpGetStringCommand;
            _meetupGroupUrl = meetupGroupUrl;
            _twitterName = twitterName;
        }

        public async Task LoadFromMeetupAsync()
        {
            var meetupGroup = new MeetupGroup(_meetupSettings, _httpGetStringCommand, _meetupGroupUrl);

            MeetupGroup = await meetupGroup.LoadFromMeetupAsync();
        }

        public string LogoFileName
        {
            get { return string.Format("{0}_200.png", _meetupGroupUrl); }
        }

        public string TwitterName { get { return _twitterName; } }

        public string MeetupGroupUrl { get { return _meetupGroupUrl; } }

        public MeetupGroup MeetupGroup { get; private set; }
        public string Name { get { return MeetupGroup.Name; } }
    }
}