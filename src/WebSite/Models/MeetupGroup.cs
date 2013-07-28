using System;
using System.Collections.Generic;
using NNUG.WebSite.ServiceAgent;

namespace NNUG.WebSite.Models
{
    public class MeetupGroup
    {
        public MeetupGroup(string name)
        {
            Name = name;
            Rating = 4.56;
            NumberOfMembers = 188;
            UpcomingEvents = new[]
                                 {
                                     new Event
                                         {
                                             Name = "Sommerfest",
                                             Description =
                                                 "<p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui. </p>",
                                             EventUrl = "http://www.meetup.com/nnug-trondheim/events/122704952/",
                                             StartTime = DateTime.Now.AddDays(1),
                                             RsvpLimit = 20,
                                             WaitListCount = 2,
                                             YesRsvpCount = 20,
                                             Venue =
                                                 new Venue
                                                     {
                                                         Name = "Clarion Hotel & Congress Trondheim",
                                                         Address1 = "VenueAddress",
                                                         City = "Venuecity",
                                                         Country = "VenueCountry"
                                                     }

                                         },
                                                                              new Event
                                         {
                                             Name = "Trondheim Developers Conference 2013",
                                             Description =
                                                 "<p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod. Donec sed odio dui. </p>",
                                             EventUrl = "http://www.meetup.com/nnug-trondheim/events/121046502/",
                                             StartTime = DateTime.Now.AddMonths(5),
                                             RsvpLimit = 20,
                                             WaitListCount = 2,
                                             YesRsvpCount = 20,
                                             Venue =
                                                 new Venue
                                                     {
                                                         Name = "Clarion Hotel & Congress Trondheim",
                                                         Address1 = "VenueAddress",
                                                         City = "Venuecity",
                                                         Country = "VenueCountry"
                                                     }

                                         }

                                 };
        }

        public string Name { get; private set; }

        public int NumberOfMembers { get; set; }

        public double Rating { get; set; }

        public Uri JoinUrl
        {
            get { return new Uri(MeetupApiClient.BaseUri, string.Format("/{0}/join/", Name)); }
        }

        public IEnumerable<Event> UpcomingEvents { get; private set; }
    }
}