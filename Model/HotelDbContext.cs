using Microsoft.EntityFrameworkCore;

namespace HotelAngular.Model
{
    public class HotelDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<House> House { get; set; }
        public DbSet<Customer> Customer { get; set; }

        public HotelDbContext()
                : base()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;User Id=postgres;Password=1111;Database=Hotel;");
        }
    }
}
