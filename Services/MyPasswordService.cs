using Core.ViewModels.MyPasswordViewModel;
using Entities;
using Repositories.Contracts;
using Services.Contracts;
using System.Security.Cryptography;

namespace Services
{
    public class MyPasswordService : IMyPasswordService
    {
        private readonly IRepositoryManager _repositoryManager;

        public MyPasswordService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public void CreateMyPassword(CreateMyPasswordViewModel myPassword)
        {
            string salt = GenerateSalt();
            string hashedPassword = HashPassword(myPassword.Password, salt);

            var result = new MyPassword
            {
                CategoryId = myPassword.CategoryId,
                IdentityUserId = myPassword.IdentityUserId,
                Description = myPassword.Description,
                Url = myPassword.Url,
                UserName = myPassword.UserName,
                Password = hashedPassword
            };
            _repositoryManager.MyPasswordRepository.Create(result);
            _repositoryManager.Save();
        }

        public void DeleteMyPassword(int id)
        {
            var result = _repositoryManager.MyPasswordRepository.FindAll(false).Where(x => x.Id == id).First();
            if (result != null)
            {
                _repositoryManager.MyPasswordRepository.DeleteMyPassword(result);
                _repositoryManager.Save();
            }
        }

        public IEnumerable<MyPassword> GetAllMyPasswordDto(bool trackChanges)
        {
            return _repositoryManager.MyPasswordRepository.GetAllMyPassword(trackChanges);
        }

        public IEnumerable<MyPassword> GetAllMyPasswordWithByCategory(bool trackChanges)
        {
            return _repositoryManager.MyPasswordRepository.GetAllMyPasswordWithByCategory(trackChanges);
        }

        public ResultMyPasswordViewModel GetOneMyPasswordById(int id, bool trackChanges)
        {
            var result = _repositoryManager.MyPasswordRepository.GetOneMyPasswordById(id, trackChanges);
            return new()
            {
                Description = result.Description,
                Url = result.Url,
                Id = result.Id,
                UserName = result.UserName,
                CategoryId = result.CategoryId,
                IdentityUserId = result.IdentityUserId,
            };
        }

        public void UpdateMyPassword(UpdateMyPasswordViewModel myPassword)
        {
            var data = _repositoryManager.MyPasswordRepository.GetOneMyPasswordById(myPassword.Id, false);
            string salt = GenerateSalt();
            string hashedPassword = HashPassword(myPassword.Password, salt);

            data.Description = myPassword.Description;
            data.CategoryId = myPassword.CategoryId;
            data.Url = myPassword.Url;
            data.UserName = myPassword.UserName;
            data.IdentityUserId = myPassword.IdentityUserId;
            data.Password = hashedPassword;

            _repositoryManager.MyPasswordRepository.Update(data);
            _repositoryManager.Save();
        }


        private static string HashPassword(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);

            // PBKDF2 ile şifreyi hash'leme
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 10000, HashAlgorithmName.SHA256))
            {
                byte[] hashBytes = pbkdf2.GetBytes(256 / 8); // 256-bit hash değeri
                return Convert.ToBase64String(hashBytes);
            }
        }
        private static string GenerateSalt()
        {
            // Rastgele bir salt oluştur
            byte[] saltBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }
    }
}
