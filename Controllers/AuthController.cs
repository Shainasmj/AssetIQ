using AssetIQ.Constants;
using AssetIQ.Models.ViewModels;
using AssetIQ.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssetIQ.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _authService.RegisterAsync(
                model.Username,
                model.Email,
                model.Password
            );

            if (!result)
            {
                ModelState.AddModelError("", "Email already exists");
                return View(model);
            }

            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            HttpContext.Session.SetString("LoginTime", DateTime.Now.ToString());
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _authService.LoginAsync(model.Email, model.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid email or password");
                return View(model);
            }

            HttpContext.Session.SetString(SessionConstants.UserEmail, user.Email);
            HttpContext.Session.SetString(SessionConstants.Username, user.Username);
            HttpContext.Session.SetString(SessionConstants.UserRole, user.Role);

            return RedirectToAction("Index", "Asset");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove(SessionConstants.UserEmail);
            return RedirectToAction("Login");
        }
    }
}