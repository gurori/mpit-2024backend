using Microsoft.EntityFrameworkCore;
using mpit.DataAccess.Entities;

namespace mpit.DataAccess.DbContexts
{
    public class ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
            : BaseDbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            ConfigureEntity<UserEntity>(modelBuilder);
        }

        protected override void ConfigureEntity<T>(ModelBuilder modelBuilder)
        {
            base.ConfigureEntity<T>(modelBuilder);

            modelBuilder.Entity<UserEntity>()
                .Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(64);
        }
    }
}
