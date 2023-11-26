using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public class MyPasswordRepository : RepositoryBase<MyPassword>, IMyPasswordRepository
    {
        public MyPasswordRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateMyPassword(MyPassword myPassword) => Create(myPassword);

        public void DeleteMyPassword(MyPassword myPassword) => Remove(myPassword);

        public IEnumerable<MyPassword> GetAllMyPassword(bool trackChanges) => FindAll(trackChanges);

        public IEnumerable<MyPassword> GetAllMyPasswordWithByCategory(bool trackChanges) => FindAll(trackChanges).Include(x => x.Category);


        public MyPassword GetOneMyPasswordById(int id, bool trackChanges) => FindAll(trackChanges).Include(x => x.Category).Where(x => x.Id == id).FirstOrDefault();

        public void UpdateMyPassword(MyPassword myPassword) => Update(myPassword);
    }
}
