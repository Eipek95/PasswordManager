using Core.ViewModels.MyPasswordViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories.Models;
using Services.Contracts;

namespace PasswordManager.Controllers
{
    [Authorize]
    public class PasswordController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly UserManager<AppUser> _userManager;

        public PasswordController(IServiceManager serviceManager, UserManager<AppUser> userManager)
        {
            _serviceManager = serviceManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
            var mypassword = _serviceManager.MyPasswordService.GetAllMyPasswordWithByCategory(false).Where(x => x.IdentityUserId == user.Id).ToList();
            return View(mypassword);
        }
        [HttpGet]
        public async Task<IActionResult> CreateMyPasswordDetail()
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
            ViewBag.id = user.Id;
            var categories = _serviceManager.CategoryService.GetAllCategory(false).ToList();
            ViewBag.categorySelectList = new SelectList(categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMyPasswordDetail(CreateMyPasswordViewModel request)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.MyPasswordService.CreateMyPassword(request);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMyPasswordDetail(int id)
        {
            var result = _serviceManager.MyPasswordService.GetOneMyPasswordById(id, false);
            var categories = _serviceManager.CategoryService.GetAllCategory(false).ToList();
            ViewBag.categorySelectList = new SelectList(categories, "Id", "Name");
            return View(new UpdateMyPasswordViewModel
            {
                CategoryId = result.CategoryId,
                Description = result.Description,
                Url = result.Url,
                IdentityUserId = result.IdentityUserId,
                UserName = result.UserName,
                Id = result.Id
            });
        }


        [HttpPost]
        public async Task<IActionResult> UpdateMyPasswordDetail(UpdateMyPasswordViewModel request)
        {
            _serviceManager.MyPasswordService.UpdateMyPassword(request);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMyPasswordDetail(int id)
        {
            _serviceManager.MyPasswordService.DeleteMyPassword(id);
            return RedirectToAction("Index");
        }
    }
}
