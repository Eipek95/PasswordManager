using Microsoft.AspNetCore.Identity;
using Repositories.Models;

namespace PasswordManager.CustomValidators
{
    public class UserValidator : IUserValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            var errors = new List<IdentityError>();
            var isDigit = int.TryParse(user.UserName![0].ToString(), out _);

            if (isDigit)
            {
                errors.Add(new()
                {
                    Code = "UserNameContainFirstLetterDigit",
                    Description = "Kullanıcı Adının ilk karekteri sayısal bir karekter içeremez"
                });
            }

            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
