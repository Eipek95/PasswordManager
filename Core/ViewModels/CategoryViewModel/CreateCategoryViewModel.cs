using System.ComponentModel.DataAnnotations;

namespace Core.ViewModels.CategoryViewModel
{
    public class CreateCategoryViewModel
    {
        public CreateCategoryViewModel()
        {

        }
        public CreateCategoryViewModel(string name, string identityUserId)
        {
            Name = name;
            IdentityUserId = identityUserId;
        }

        [Required(ErrorMessage = "Kategori Adı Boş Bırakılamaz")]
        [Display(Name = "Kategori Adı :")]
        public string Name { get; set; }
        public string IdentityUserId { get; set; }
    }
}
