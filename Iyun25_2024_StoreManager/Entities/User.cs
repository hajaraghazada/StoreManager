namespace Iyun25_2024_StoreManager.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Role> Roles { get; set; }
    }
}
