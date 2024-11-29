using Microsoft.EntityFrameworkCore;
using TeamF.Models;
namespace TeamF.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Tracking> Trackings { get; set; }
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<DeliveryDetails> DeliveryDetails { get; set; }

    }
}
