using Azure.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AdAgency.Models;

namespace AdAgency.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<AdOrder> Orders { get; set; }
        public DbSet<OrderRequest> Requests { get; set; }
        public DbSet<AdCategory> AdCategories { get; set; }

    }
}
