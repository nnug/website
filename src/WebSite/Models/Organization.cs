using System.Collections.Generic;
using System.Threading.Tasks;
using NNUG.WebSite.Integration;
using NNUG.WebSite.ServiceAgent;

namespace NNUG.WebSite.Models
{
    public class Organization
    {
        public List<Chapter> Chapters { get; set; }

        public static async Task<Organization> Create(IMeetupSettings meetupSettings, IHttpGetStringCommand httpGetStringCommand)
        {
            var organization = new Organization();
            organization.Chapters = new List<Chapter>
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

            foreach (var chapter in organization.Chapters)
            {
                await chapter.LoadFromMeetupAsync();
            }

            return organization;
        }
    }
}