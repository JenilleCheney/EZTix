using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EZTix.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _configuration;

        // Constructor
        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: /Account/Login
        public IActionResult Login(string? returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password, string? returnUrl)
        {
            // Read credentials from configuration (user secrets use Eztix:Username/Eztix:Password)
            var configuredUsername = _configuration["Eztix:Username"];
            var configuredPassword = _configuration["Eztix:Password"];

            if (username == configuredUsername && password == configuredPassword)
            {
                // Build claims list
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, username),
                    new Claim(ClaimTypes.Name, "EZTix Admin")
                };

                // Create identity and principal
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Sign in
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                // Redirect to original page or default
                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index", "Shows");
            }

            ViewBag.ErrorMessage = "Invalid username or password.";
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // GET: /Account/Logout
        public IActionResult Logout()
        {
            return View();
        }

        // POST: /Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogoutConfirmed()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}

