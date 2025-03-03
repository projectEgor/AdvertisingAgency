using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AdvAgency.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvAgency.Data
{
    public class AppDbContext : IdentityDbContext<Users>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AdvertCategory> AdvertCategories { get; set; }
        public DbSet<AdOrder> AdOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
