using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AdvAgency.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvAgency.Data
{
    public class AppDbContext : IdentityDbContext<Users>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
