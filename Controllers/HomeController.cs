using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace BulkyWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //the action mehtods
        public IActionResult Index()//this is for the index.cshtml this action method take you to the index
        {
            return View();
        }

        public IActionResult Privacy()//this is for Privecy.cshtml
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
