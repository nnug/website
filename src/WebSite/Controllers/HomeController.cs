using System.Threading.Tasks;
using System.Web.Mvc;
using NNUG.WebSite.Integration;
using NNUG.WebSite.Models;
using NNUG.WebSite.ServiceAgent;

namespace NNUG.WebSite.Controllers
{
    public class HomeController : Controller
    {
        //[OutputCache(Duration = 60)]
        public async Task<ActionResult> Index()
        {
            return View(await Organization.Create(new MeetupSettings(), new HttpGetStringFromEmbeddedResourceCommand()));
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
