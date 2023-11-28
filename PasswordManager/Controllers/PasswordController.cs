using Core.ViewModels.MyPasswordViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace PasswordManager.Controllers
{
    [Authorize]
    public class PasswordController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private string userName => User.Identity!.Name!;
        public PasswordController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<IActionResult> Index()
        {
            var mypassword = await _serviceManager.MyPasswordService.GetAllMyPasswordWithCategoryByIdentityUserNameAsync(userName, false);
            return View(mypassword);
        }
        [HttpGet]
        public async Task<IActionResult> CreateMyPasswordDetail()
        {
            ViewBag.id = await _serviceManager.AuthService.GetIdentityUserIdrwithIdentityUserNameAsync(userName);
            var categories = await _serviceManager.CategoryService.GetAllCategoriesWithByIdentityUserName(userName, false);
            ViewBag.categorySelectList = new SelectList(categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult CreateMyPasswordDetail(CreateMyPasswordViewModel request)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.MyPasswordService.CreateMyPassword(request);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateMyPasswordDetail(int id)
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
        public IActionResult UpdateMyPasswordDetail(UpdateMyPasswordViewModel request)
        {
            _serviceManager.MyPasswordService.UpdateMyPassword(request);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteMyPasswordDetail(int id)
        {
            _serviceManager.MyPasswordService.DeleteMyPassword(id);
            return RedirectToAction("Index");
        }
    }
}
