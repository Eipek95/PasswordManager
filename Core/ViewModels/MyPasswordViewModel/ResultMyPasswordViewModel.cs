namespace Core.ViewModels.MyPasswordViewModel
{
    public class ResultMyPasswordViewModel
    {
        public ResultMyPasswordViewModel()
        {

        }
        public ResultMyPasswordViewModel(int id, string description, string url, string userName, string password, int categoryId, string identityUserId)
        {
            Id = id;
            Description = description;
            Url = url;
            UserName = userName;
            Password = password;
            CategoryId = categoryId;
            IdentityUserId = identityUserId;
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CategoryId { get; set; }

        public string IdentityUserId { get; set; }
    }
}
