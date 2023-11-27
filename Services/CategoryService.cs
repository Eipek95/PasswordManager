using Core.ViewModels.CategoryViewModel;
using Entities;
using Microsoft.AspNetCore.Identity;
using Repositories.Contracts;
using Repositories.Models;
using Services.Contracts;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly UserManager<AppUser> _userManager;

        public CategoryService(IRepositoryManager repositoryManager, UserManager<AppUser> userManager)
        {
            _repositoryManager = repositoryManager;
            _userManager = userManager;
        }

        public void CreateCategory(CreateCategoryViewModel category)
        {
            var result = new Category
            {
                Name = category.Name,
                IdentityUserId = category.IdentityUserId,
            };
            _repositoryManager.CategoryRepository.Create(result);
            _repositoryManager.Save();
        }

        public bool DeleteCategory(int id)
        {
            var result = _repositoryManager.MyPasswordRepository.FindAll(false).Where(x => x.CategoryId == id).Any();
            if (!result)
            {
                var category = _repositoryManager.CategoryRepository.FindByCondition(x => x.Id == id, false);
                _repositoryManager.CategoryRepository.DeleteCategory(category);
                _repositoryManager.Save();

                return true;
            }
            return false;
        }

        public async Task<List<Category>> GetAllCategoriesWithByIdentityUserName(string userName, bool trackChanges)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var categories = GetAllCategory(trackChanges).Where(x => x.IdentityUserId == user!.Id).ToList();
            return categories;
        }

        public IEnumerable<Category> GetAllCategory(bool trackChanges)
        {
            return _repositoryManager.CategoryRepository.GetAllCategory(trackChanges);
        }


        public Category GetOneCategoryById(int id, bool trackChanges)
        {
            return _repositoryManager.CategoryRepository.GetOneCategoryById(id, trackChanges);
        }

        public void UpdateCategory(UpdateCategoryViewModel category)
        {
            var result = new Category
            {
                Id = category.Id,
                Name = category.Name,
                IdentityUserId = category.IdentityUserId,
            };
            _repositoryManager.CategoryRepository.Update(result);
            _repositoryManager.Save();
        }
    }
}
