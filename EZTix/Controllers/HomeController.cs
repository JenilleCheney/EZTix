using EZTix.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EZTix.Controllers
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
            List<Show> shows = new List<Show>();
            Show show1 = new Show();
            show1.ShowID = 1;
            show1.Title = "The Shenanigans";
            show1.Description = "Get Wild to the beats of The Shenanigans";
            show1.ShowTime = new DateTime(2025, 10, 31, 20, 30, 00);
            show1.Owner = "Carol Baskins";
            show1.Created = DateTime.Now;
            show1.CategoryId = 1;
            show1.VenueId = 1;
            Show show2 = new Show();
            show2.ShowID = 2;
            show2.Title = "Jazz in the Park";
            show2.Description = "Smooth Jazz Evening";
            show2.ShowTime = new DateTime(2024, 7, 15, 18, 00, 00);
            show2.Owner = "John Doe";
            show2.Created = DateTime.Now;
            show2.CategoryId = 2;
            show2.VenueId = 2;
            Show show3 = new Show();
            return View(shows);
        }

      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
