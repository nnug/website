using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using NNUG.WebSite.Core.Integration;
using NNUG.WebSite.Models;

namespace NNUG.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private const string CacheKeyOrganization = "Organization";

        private readonly IHttpGetStringCommand _httpGetStringCommand;
        private readonly IMemoryCache _cache;

        public HomeController(IHttpGetStringCommand httpGetStringCommand, IMemoryCache cache)
        {
            _httpGetStringCommand = httpGetStringCommand;
            _cache = cache;
        }

        public async Task<IActionResult> Index()
        {
            var organization = await _cache.GetOrCreateAsync(CacheKeyOrganization, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);
                return Organization.Create(_httpGetStringCommand);
            });

            return View(organization);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Faq()
        {
            return View();
        }

        public IActionResult Speaker()
        {
            return View();
        }

        public IActionResult StartChapter()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
