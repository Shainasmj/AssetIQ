using Microsoft.EntityFrameworkCore;
using AssetIQ.Models.Domain;

namespace AssetIQ.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<User> Users { get; set; }
    }
}