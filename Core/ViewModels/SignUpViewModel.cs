using Core.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace Core.ViewModels
{
    public class SignUpViewModel
    {
        public SignUpViewModel()
        {

        }
        public SignUpViewModel(string userName, string email, string password, string passwordConfirm)
        {
            UserName = userName;
            Email = email;
            Password = password;
            PasswordConfirm = passwordConfirm;
        }

        [Required(ErrorMessage = "Kullanıcı Adı Boş Bırakılamaz")]
        [Display(Name = "Kullanıcı Adı :")]
        public string UserName { get; set; }
        [EmailAddress(ErrorMessage = "Email Formatı Yanlış")]
        [Required(ErrorMessage = "Email Boş Bırakılamaz")]
        [Display(Name = "Email Adresiniz :")]
        public string Email { get; set; }

        // [DataType(DataType.Password)]
        [ComplexCharacterCheck]
        [Required(ErrorMessage = "Şifre Boş Bırakılamaz")]
        [Display(Name = "Şifre :")]
        public string Password { get; set; } = null!;

        //[DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Şifre Aynı Değildir")]
        [Required(ErrorMessage = "Şifre Tekrar Boş Bırakılamaz")]
        [Display(Name = "Şifre Tekrar:")]
        public string PasswordConfirm { get; set; } = null!;
    }
}
