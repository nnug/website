using System;

namespace NNUG.WebSite.Models
{
    public class Event
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime StartTime { get; set; }
        // utc_offset time

        public int RsvpLimit { get; set; }
        public int YesRsvpCount { get; set; }
        public int WaitListCount { get; set; }

        public string EventUrl { get; set; }
        public Venue Venue { get; set; }
    }
}