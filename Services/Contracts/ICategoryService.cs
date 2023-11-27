using Core.ViewModels.CategoryViewModel;
using Entities;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategory(bool trackChanges);
        Category GetOneCategoryById(int id, bool trackChanges);
        void CreateCategory(CreateCategoryViewModel category);
        void UpdateCategory(UpdateCategoryViewModel category);
        bool DeleteCategory(int id);
        Task<List<Category>> GetAllCategoriesWithByIdentityUserName(string userName, bool trackChanges);
    }
}
