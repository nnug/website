using System;
using System.Threading.Tasks;
using NNUG.WebSite.Core.Integration;
using NNUG.WebSite.Core.ServiceAgent;

namespace NNUG.WebSite.Models
{
    public class Chapter
    {
        private readonly IMeetupSettings _meetupSettings;
        private readonly IHttpGetStringCommand _httpGetStringCommand;

        public Chapter(IMeetupSettings meetupSettings, IHttpGetStringCommand httpGetStringCommand, string meetupGroupUrl, string name, string twitterName)
        {
            _meetupSettings = meetupSettings;
            _httpGetStringCommand = httpGetStringCommand;
            Name = name;
            MeetupGroupUrl = meetupGroupUrl;
            TwitterName = twitterName;
        }

        public async Task LoadFromMeetupAsync()
        {
            var meetupGroup = new MeetupGroup(_meetupSettings, _httpGetStringCommand, MeetupGroupUrl);

            MeetupGroup = await meetupGroup.LoadFromMeetupAsync();
        }

        public string MeetupGroupUrl { get; private set; }
        public string Name { get; private set; }
        public string TwitterName { get; private set; }

        public string LogoFileName
        {
            get { return string.Format("{0}_200.png", MeetupGroupUrl); }
        }

        public Uri JoinUrl
        {
            get { return new Uri(MeetupApiClient.BaseUri, string.Format("/{0}/join/", MeetupGroupUrl)); }
        }

        public MeetupGroup MeetupGroup { get; private set; }
        public int NumberOfMembers { get { return MeetupGroup != null ? MeetupGroup.Members : 0; } }
    }
}