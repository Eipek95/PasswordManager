using Microsoft.AspNetCore.Identity;

namespace PasswordManager.Localizations
{
    public class LocalizationIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateEmail(string email)
        {
            return new()
            {
                Code = "DuplicateEmail",
                Description = $"{email} adresi ile daha önceden hesap oluşturulmuştur"
            };

        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return new()
            {
                Code = "DuplicateUserName",
                Description = $"{userName} kullanıcı adı ile daha önceden hesap oluşturulmuştur"
            };
        }
    }
}
