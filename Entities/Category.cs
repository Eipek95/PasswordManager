namespace Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdentityUserId { get; set; }
        public List<MyPassword> MyPassword { get; set; }
    }
}
