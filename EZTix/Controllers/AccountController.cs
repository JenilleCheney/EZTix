using Microsoft.AspNetCore.Mvc;

namespace EZTix.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
