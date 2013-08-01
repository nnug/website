using System.Web.Mvc;
using NNUG.WebSite.Models;

namespace NNUG.WebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(Organization.Create());
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

        [ChildActionOnly]
        //[OutputCache(VaryByParam = "chapter", Duration = 60)]
        public PartialViewResult ChapterTile(Chapter chapter)
        {
            return PartialView(chapter);
        }
    }
}
