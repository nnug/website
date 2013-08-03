using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Web.Mvc;
using NNUG.WebSite.Core.Integration;
using NNUG.WebSite.Core.ServiceAgent;
using NNUG.WebSite.Models;

namespace NNUG.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private const string AppSettingsKeyUseDesignTimeData = "useDesignTimeData";
        private const string CacheKeyOrganization = "Organization";

        public async Task<ActionResult> Index()
        {
            if (ConfigurationManager.AppSettings[AppSettingsKeyUseDesignTimeData]
                .Equals("true", StringComparison.InvariantCultureIgnoreCase))
            {
                return View(await Organization.Create(new MeetupSettings(), new HttpGetStringFromEmbeddedResourceCommand()));
            }
            
            return View(await RetrieveFromCache());
        }

        private async Task<Organization> RetrieveFromCache()
        {
            if (HttpContext.Cache[CacheKeyOrganization] == null)
            {
                Organization organization = await Organization.Create(new MeetupSettings(), new HttpGetStringCommand());
                HttpContext.Cache.Add(CacheKeyOrganization, organization, null, DateTime.Now.AddHours(1),
                    Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
            }

            return (Organization)HttpContext.Cache[CacheKeyOrganization];
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Faq()
        {
            return View();
        }

        public ActionResult Speaker()
        {
            return View();
        }

        public ActionResult StartChapter()
        {
            return View();
        }
    }
}
