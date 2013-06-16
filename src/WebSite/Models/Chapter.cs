namespace NNUG.WebSite.Models
{
    public class Chapter
    {
        private string _meetupGroupName;

        public Chapter(string name, string meetupGroupName = null)
        {
            _meetupGroupName = meetupGroupName ?? string.Format("nnug-{0}", name.ToLowerInvariant());

            Name = name;
            MeetupGroup = new MeetupGroup(_meetupGroupName);
        }

        public string Name { get; private set; }

        public string LogoFileName
        {
            get { return string.Format("NNUG{0}_200.png", Name); }
        }

        public string TwitterName
        {
            get { return string.Format("NNUG{0}", Name); }
        }

        public string MeetupGroupName { get { return _meetupGroupName; } }

        public MeetupGroup MeetupGroup { get; private set; }
    }
}