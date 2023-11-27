using System.ComponentModel.DataAnnotations;

namespace Core.ViewModels.CategoryViewModel
{
    public class UpdateCategoryViewModel
    {
        public UpdateCategoryViewModel()
        {

        }
        public UpdateCategoryViewModel(int id, string name, string identityUserId)
        {
            Id = id;
            Name = name;
            IdentityUserId = identityUserId;
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Kategori Adı Boş Bırakılamaz")]
        [Display(Name = "Kategori Adı :")]
        public string Name { get; set; }
        public string IdentityUserId { get; set; }

    }
}
