using Microsoft.EntityFrameworkCore;
using mpit.DataAccess.Entities;

namespace mpit.DataAccess.DbContexts
{
    public class UserDbContext(
        DbContextOptions<UserDbContext> options)
            : BaseDbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);

            ConfigureEntity<UserEntity>(modelBuilder);

            //modelBuilder.ApplyConfiguration(new RolePermissionConfiguration(authOptions.Value));
        }

        protected override void ConfigureEntity<T>(ModelBuilder modelBuilder)
        {
            base.ConfigureEntity<T>(modelBuilder);

            modelBuilder.Entity<UserEntity>()
                .Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(64);

            modelBuilder.Entity<UserEntity>()
                .HasData(new { Id = Guid.NewGuid(), UserName = "Olegushka" });
        }
    }
}
