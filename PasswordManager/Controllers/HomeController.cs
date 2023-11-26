using Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.Infrastructure.Extensions;
using PasswordManager.Models;
using Repositories.Models;
using System.Diagnostics;

namespace PasswordManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> SignIn()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Password");
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel request, string? returnUrl = null)
        {

            returnUrl = returnUrl ?? Url.Action("Index", "Password");

            var hasUser = await _userManager.FindByEmailAsync(request.Email);
            if (hasUser == null)
            {
                ModelState.AddModelError(string.Empty, "Email veya Þifre Yanlýþ");
                return View();
            }

            var signInResult = await _signInManager.PasswordSignInAsync(hasUser, request.Password, request.RememberMe, true);

            if (signInResult.Succeeded)
            {
                return Redirect(returnUrl);
            }


            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelErrorList(new List<string>() { "Üç Dakika Boyunca Giriþ Yapamazsýnýz" });
                return View();
            }


            ModelState.AddModelErrorList(new List<string>() { "Email veya Þifre Yanlýþ", $"Baþarýsýz Giriþ Sayýsý= {await _userManager.GetAccessFailedCountAsync(hasUser)}" });

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

            if (!ModelState.IsValid) return View();


            var identityResult = await _userManager.CreateAsync(new()
            {
                UserName = request.UserName,
                Email = request.Email,

            }, request.Password);


            if (identityResult.Succeeded)
            {
                TempData["SuccessMessage"] = "Üyelik kayýt iþlemi baþarýyla gerçekleþmiþtir";
                return RedirectToAction(nameof(HomeController.SignUp));
            }

            ModelState.AddModelErrorList(identityResult.Errors.Select(x => x.Description).ToList());
            return View();

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}