using Entities;

namespace Repositories.Contracts
{
    public interface IMyPasswordRepository : IRepositoryBase<MyPassword>
    {
        IEnumerable<MyPassword> GetAllMyPassword(bool trackChanges);
        MyPassword GetOneMyPasswordById(int id, bool trackChanges);
        IEnumerable<MyPassword> GetAllMyPasswordWithByCategory(bool trackChanges);
        void CreateMyPassword(MyPassword myPassword);
        void UpdateMyPassword(MyPassword myPassword);
        void DeleteMyPassword(MyPassword myPassword);
    }
}
