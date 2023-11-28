using Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Infrastructure.Extensions;
using PasswordManager.Models;
using Services.Contracts;
using System.Diagnostics;
using System.Security.Claims;

namespace PasswordManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthService _authService;

        public HomeController(ILogger<HomeController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult SignIn()
        {

            ClaimsPrincipal user = HttpContext.User;
            var isUserSignedIn = _authService.IsUserSignedIn(user);

            if (isUserSignedIn)
            {
                return RedirectToAction("Index", "Password");
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel request, string? returnUrl = null)
        {

            returnUrl = returnUrl ?? Url.Action("Index", "Password");

            var signInResult = await _authService.SignInAsync(request.Email, request.Password, request.RememberMe);

            if (signInResult.Succeeded)
            {
                return Redirect(returnUrl);
            }

            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelErrorList(new List<string>() { "Üç Dakika Boyunca Giriþ Yapamazsýnýz" });
                return View();
            }

            var accessFailedCount = await _authService.GetAccessFailedCountAsync(request.Email);

            ModelState.AddModelErrorList(new List<string>() { "Email veya Þifre Yanlýþ", $"Baþarýsýz Giriþ Sayýsý= {accessFailedCount}" });

            return View();
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel request)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var identityResult = await _authService.RegisterUserAsync(request.UserName, request.Email, request.Password);

            if (identityResult.Succeeded)
            {
                TempData["SuccessMessage"] = "Üyelik kayýt iþlemi baþarýyla gerçekleþmiþtir";
                return RedirectToAction(nameof(HomeController.SignUp));
            }

            ModelState.AddModelErrorList(identityResult.Errors.Select(x => x.Description).ToList());
            return View();

        }


        [Authorize]
        [HttpGet]
        public async Task LogOut()
        {
            await _authService.LogOut();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}