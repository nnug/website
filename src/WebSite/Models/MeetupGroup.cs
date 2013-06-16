using System;
using System.Collections.Generic;

namespace NNUG.WebSite.Models
{
    public class MeetupGroup
    {
        public MeetupGroup(string name)
        {
            Name = name;
            UpcomingEvents = new[]
                                 {
                                     new Event
                                         {
                                             Name = "Event name 1",
                                             Description =
                                                 "<p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui. </p>",
                                             EventUrl = "http://meetup.com",
                                             StartTime = DateTime.Now.AddDays(1),
                                             RsvpLimit = 20,
                                             WaitListCount = 2,
                                             YesRsvpCount = 20,
                                             Venue =
                                                 new Venue
                                                     {
                                                         Name = "VenueName",
                                                         Address = "VenueAddress",
                                                         City = "Venuecity",
                                                         Country = "VenueCountry"
                                                     }

                                         },
                                                                              new Event
                                         {
                                             Name = "Event name 2",
                                             Description =
                                                 "<p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui. </p>",
                                             EventUrl = "http://meetup.com",
                                             StartTime = DateTime.Now.AddMonths(1),
                                             RsvpLimit = 20,
                                             WaitListCount = 2,
                                             YesRsvpCount = 20,
                                             Venue =
                                                 new Venue
                                                     {
                                                         Name = "VenueName",
                                                         Address = "VenueAddress",
                                                         City = "Venuecity",
                                                         Country = "VenueCountry"
                                                     }

                                         }

                                 };
        }

        public string Name { get; private set; }

        public IEnumerable<Event> UpcomingEvents { get; private set; }
    }
}