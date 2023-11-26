using Entities;
using Repositories.Contracts;

namespace Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateCategory(Category category) => Create(category);

        public void DeleteCategory(Category category) => Remove(category);

        public IEnumerable<Category> GetAllCategory(bool trackChanges) => FindAll(trackChanges);

        public Category GetOneCategoryById(int id, bool trackChanges) => FindByCondition(x => x.Id == id, trackChanges);

        public void UpdateCategory(Category category) => Update(category);
    }
}
