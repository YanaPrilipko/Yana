namespace HotelAngular.Model
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public Role? Role { get; set; } = new Role();

        public int? RoleId { get; set; }
        public string Password { get; set; }
    }
}
