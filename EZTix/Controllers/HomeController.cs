using EZTix.Data;
using EZTix.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EZTix.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // ADDED
        private readonly EZTixContext _context;

        public HomeController(ILogger<HomeController> logger, EZTixContext context)
        {
            _logger = logger;
            // ADDED
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // ADDED
            var shows = await _context.Show
                .OrderBy(e => e.ShowTime)
                .ToListAsync();
            return View(shows);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
