using Core.ViewModels.CategoryViewModel;
using Entities;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _repositoryManager;


        public CategoryService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
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

        public void DeleteCategory(int id)
        {
            var result = _repositoryManager.CategoryRepository.FindAll(false).Where(x => x.Id == id).First();
            if (result != null)
            {
                _repositoryManager.CategoryRepository.DeleteCategory(result);
                _repositoryManager.Save();
            }
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
