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
        void DeleteCategory(int id);
    }
}
