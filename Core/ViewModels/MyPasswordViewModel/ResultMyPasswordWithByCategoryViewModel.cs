namespace Core.ViewModels.MyPasswordViewModel
{
    public class ResultMyPasswordWithByCategoryViewModel
    {
        public ResultMyPasswordWithByCategoryViewModel()
        {

        }

        public ResultMyPasswordWithByCategoryViewModel(string description, string url, string userName, string password, int categoryId, string categoryName)
        {
            Description = description;
            Url = url;
            UserName = userName;
            Password = password;
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public string Description { get; set; }
        public string Url { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
