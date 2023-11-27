using Core.ViewModels.CategoryViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repositories.Models;
using Services.Contracts;

namespace PasswordManager.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly UserManager<AppUser> _userManager;

        public CategoryController(IServiceManager serviceManager, UserManager<AppUser> userManager)
        {
            _serviceManager = serviceManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
            var mycategories = _serviceManager.CategoryService.GetAllCategory(false).Where(x => x.IdentityUserId == user!.Id).ToList();

            return View(mycategories);
        }

        public async Task<IActionResult> CreateCategory()
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
            ViewBag.id = user!.Id;

            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryViewModel request)
        {
            _serviceManager.CategoryService.CreateCategory(request);
            return RedirectToAction("Index", "Category");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var result = _serviceManager.CategoryService.GetOneCategoryById(id, false);
            return View(new UpdateCategoryViewModel
            {
                Id = id,
                IdentityUserId = result.IdentityUserId,
                Name = result.Name,
            });
        }

        [HttpPost]
        public IActionResult UpdateCategory(UpdateCategoryViewModel request)
        {
            _serviceManager.CategoryService.UpdateCategory(request);
            return RedirectToAction("Index", "Category");
        }
    }
}
