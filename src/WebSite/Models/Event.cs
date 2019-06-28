using System;
using ServiceStack.Text;

namespace NNUG.WebSite.Models
{
    public class Event
    {
        public string Name { get; set; }

        public DateTime StartTime
        {
            get
            {
                return Time.FromUnixTimeMs(TimeSpan.FromMilliseconds(UtcOffset));
            }
            set
            {
                Time = value.ToUnixTimeMsAlt();
                UtcOffset = TimeZoneInfo.Local.GetUtcOffset(value).Milliseconds;
            }
        }

        public long Time { get; set; }
        public long UtcOffset { get; set; }

        public string EventUrl { get; set; }
        public Venue Venue { get; set; }
    }
}