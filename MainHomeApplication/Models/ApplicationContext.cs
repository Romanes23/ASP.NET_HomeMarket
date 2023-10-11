using Microsoft.EntityFrameworkCore;
namespace MainHomeApplication.Models
{

    public class ApplicationContext : DbContext
    {
        public DbSet<Home> Homes { get; set; } = null!;
        public DbSet<ServiceUser> ServiceUsers { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
