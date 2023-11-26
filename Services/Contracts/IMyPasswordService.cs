using Core.ViewModels.MyPasswordViewModel;
using Entities;

namespace Services.Contracts
{
    public interface IMyPasswordService
    {
        IEnumerable<MyPassword> GetAllMyPasswordDto(bool trackChanges);
        IEnumerable<MyPassword> GetAllMyPasswordWithByCategory(bool trackChanges);
        ResultMyPasswordViewModel GetOneMyPasswordById(int id, bool trackChanges);
        void CreateMyPassword(CreateMyPasswordViewModel myPassword);
        void UpdateMyPassword(UpdateMyPasswordViewModel myPassword);
        void DeleteMyPassword(int id);
    }
}
