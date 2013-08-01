namespace NNUG.WebSite.Models
{
    public class Chapter
    {
        private string _meetupGroupName;
        private string _twitterName;

        public Chapter(string name, string meetupGroupName = null, string twitterName = null)
        {
            Name = name;

            _meetupGroupName = meetupGroupName ?? string.Format("nnug-{0}", name.ToLowerInvariant());
            _twitterName = twitterName ?? string.Format("NNUG{0}", name);
            MeetupGroup = new MeetupGroup(_meetupGroupName);
        }

        public string Name { get; private set; }

        public string LogoFileName
        {
            get { return string.Format("NNUG{0}_200.png", Name); }
        }

        public string TwitterName { get { return _twitterName; } }

        public string MeetupGroupName { get { return _meetupGroupName; } }

        public MeetupGroup MeetupGroup { get; private set; }
    }
}