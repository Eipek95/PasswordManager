namespace Core.ViewModels.MyPasswordViewModel
{
    public class ResultMyPasswordViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CategoryId { get; set; }

        public string IdentityUserId { get; set; }
    }
}
