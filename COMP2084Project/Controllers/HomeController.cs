using COMP2084Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace COMP2084Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddGenre()
        {
            return View();
        }
        public IActionResult AddList()
        {
            return View();
        }
        public IActionResult AddRating()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}