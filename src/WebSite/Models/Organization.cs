using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NNUG.WebSite.Core.Integration;
using NNUG.WebSite.Core.ServiceAgent;

namespace NNUG.WebSite.Models
{
    public class Organization
    {
        public List<Chapter> Chapters { get; set; }

        public static async Task<Organization> Create(IMeetupSettings meetupSettings, IHttpGetStringCommand httpGetStringCommand)
        {
            var organization = new Organization();
            var chapters = new List<Chapter>
                           {
                               //new Chapter(meetupSettings, httpGetStringCommand, "nnug-online", "NNUGOnline"),
                               new Chapter(meetupSettings, httpGetStringCommand, "nnugoslo", "NNUGOslo"),
                               new Chapter(meetupSettings, httpGetStringCommand, "nnug-bergen", "NNUGBergen"),
                               new Chapter(meetupSettings, httpGetStringCommand, "nnug-trondheim", "NNUGTrondheim"),
                               new Chapter(meetupSettings, httpGetStringCommand, "nnug-stavanger", "NNUGStavanger"),
                               new Chapter(meetupSettings, httpGetStringCommand, "nnug-kristiansand", ""),
                               new Chapter(meetupSettings, httpGetStringCommand, "nnug-haugesund", "NNUGHaugesund"),
                               new Chapter(meetupSettings, httpGetStringCommand, "nnug-vestfold", "NNUGVestfold")
                           };

            foreach (var chapter in chapters)
            {
                await chapter.LoadFromMeetupAsync();
            }

            organization.Chapters = chapters.OrderByDescending(c => c.MeetupGroup.Members).ToList();

            return organization;
        }
    }
}