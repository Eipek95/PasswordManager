using Core.ViewModels.CategoryViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace PasswordManager.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private string userName => User.Identity!.Name!;
        public CategoryController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<IActionResult> Index()
        {
            var mycategories = await _serviceManager.CategoryService.GetAllCategoriesWithByIdentityUserName(userName, false);
            return View(mycategories);
        }

        public async Task<IActionResult> CreateCategory()
        {

            var category = new CreateCategoryViewModel
            {
                IdentityUserId = await _serviceManager.AuthService.GetIdentityUserIdrwithIdentityUserNameAsync(userName)
            };
            return View(category);
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

        public bool DeleteCategory(int id)
        {
            var result = _serviceManager.CategoryService.DeleteCategory(id);
            return result;
        }
    }
}
