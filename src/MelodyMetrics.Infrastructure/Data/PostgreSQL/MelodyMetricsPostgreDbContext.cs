using MelodyMetrics.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace MelodyMetrics.Infrastructure.Data.PostgreSQL
{
    public class MelodyMetricsPostgreDbContext(DbContextOptions<MelodyMetricsPostgreDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserPlatform> UserPlatforms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
