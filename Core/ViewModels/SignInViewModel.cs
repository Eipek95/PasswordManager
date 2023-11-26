using System.ComponentModel.DataAnnotations;

namespace Core.ViewModels
{
    public class SignInViewModel
    {
        public SignInViewModel()
        {

        }

        public SignInViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        [EmailAddress(ErrorMessage = "Email Formatı Yanlış")]
        [Required(ErrorMessage = "Email Boş Bırakılamaz")]
        [Display(Name = "Email Adresiniz :")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre Boş Bırakılamaz")]
        [Display(Name = "Şifre :")]
        public string Password { get; set; } = null!;
        [Display(Name = "Beni Hatırla ")]

        public bool RememberMe { get; set; }
    }
}
