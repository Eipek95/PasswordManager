﻿using Core.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace Core.ViewModels.MyPasswordViewModel
{

    public class UpdateMyPasswordViewModel
    {
        public UpdateMyPasswordViewModel()
        {

        }

        public UpdateMyPasswordViewModel(int id, string identityUserId, string userName, string description, string url, int categoryId, string password, string passwordConfirm)
        {
            Id = id;
            IdentityUserId = identityUserId;
            UserName = userName;
            Description = description;
            Url = url;
            CategoryId = categoryId;
            Password = password;
            PasswordConfirm = passwordConfirm;
        }

        public int Id { get; set; }
        public string IdentityUserId { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adı Boş Bırakılamaz")]
        [Display(Name = "Kullanıcı Adı :")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Kayıt Tanımı Boş Bırakılamaz")]
        [Display(Name = "Kayıt Tanımı :")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Url Alanı Boş Bırakılamaz")]
        [Display(Name = "Url :")]
        public string Url { get; set; }

        [Required(ErrorMessage = "Kategori Boş Bırakılamaz")]
        [Display(Name = "Kategori :")]
        public int CategoryId { get; set; }
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
