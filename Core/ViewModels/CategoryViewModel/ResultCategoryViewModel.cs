namespace Core.ViewModels.CategoryViewModel
{
    public class ResultCategoryViewModel
    {
        public ResultCategoryViewModel()
        {

        }

        public ResultCategoryViewModel(int id, string name, string identityUserId)
        {
            Id = id;
            Name = name;
            IdentityUserId = identityUserId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string IdentityUserId { get; set; }

    }
}
