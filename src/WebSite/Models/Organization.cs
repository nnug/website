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

        public static async Task<Organization> Create(IHttpGetStringCommand httpGetStringCommand)
        {
            var organization = new Organization();
            var chapters = new List<Chapter>
                           {
                               //new Chapter(meetupSettings, httpGetStringCommand, "nnug-online", "NNUG Online", "NNUGOnline"),
                               new Chapter(httpGetStringCommand, "nnugoslo", "NNUG Oslo", "NNUGOslo"),
                               new Chapter(httpGetStringCommand, "bitshift", "BitShift", "BitShiftBergen"),
                               new Chapter(httpGetStringCommand, "nnug-trondheim", "NNUG Trondheim", "NNUGTrondheim"),
                               new Chapter(httpGetStringCommand, "nnug-stavanger", "NNUG Stavanger", "NNUGStavanger"),
                               new Chapter(httpGetStringCommand, "nnug-kristiansand", "NNUG Kristiansand", ""),
                               new Chapter(httpGetStringCommand, "nnug-haugesund", "NNUG Haugesund", "NNUGHaugesund"),
                               new Chapter(httpGetStringCommand, "nnug-vestfold", "NNUG Vestfold", "NNUGVestfold"),
                           };

            foreach (var chapter in chapters)
            {
                await chapter.LoadFromMeetupAsync();
            }

            organization.Chapters = chapters.OrderByDescending(c => c.NumberOfMembers).ToList();

            return organization;
        }
    }
}