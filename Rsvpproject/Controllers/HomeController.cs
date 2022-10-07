using Microsoft.AspNetCore.Mvc;
using Rsvpproject.Models;
using System.Diagnostics;

namespace Rsvpproject.Controllers
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
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView");
        }
        [HttpGet]
        public IActionResult RsvpForm()
        {
            return View();
        }
        [HttpPost]

        public IActionResult RsvpForm(GuestResponse guestresponse)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestresponse);
                return View("Thanks", guestresponse);
            }
            else
                return View();

        }
        public IActionResult ListResponses()
        {
            return View(Repository.Responses.Where(r => r.WillAttend == true));
        }

        public IActionResult Privacy()
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