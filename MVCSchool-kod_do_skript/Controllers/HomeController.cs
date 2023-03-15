using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCSchool_kod_do_skript.Models;
using System.Diagnostics;

namespace MVCSchool_kod_do_skript.Controllers {
    [Authorize]
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private UserManager<AppUser> userManager;
        public HomeController(UserManager<AppUser> userMgr) {
            userManager = userMgr;
        }

        public async Task<IActionResult> Index() {
            AppUser user = await userManager.GetUserAsync(HttpContext.User);
            string message = $"Hello {user.UserName}";
            return View("Index", message);
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}