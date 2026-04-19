using Microsoft.EntityFrameworkCore;

namespace AssetIQ.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Tables will be added here later
    }
}