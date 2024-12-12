using Microsoft.EntityFrameworkCore;
using mpit.DataAccess.Entities;

namespace mpit.DataAccess.DbContexts
{
    public abstract class BaseDbContext(DbContextOptions options)
        : DbContext(options)
    {
        protected virtual void ConfigureEntity<T>(ModelBuilder modelBuilder)
            where T : Entity
        {
            modelBuilder.Entity<T>()
                .HasKey(x => x.Id);
        }
    }
}
