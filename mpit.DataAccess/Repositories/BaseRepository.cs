using AutoMapper;
using Microsoft.EntityFrameworkCore;
using mpit.DataAccess.DbContexts;
using mpit.DataAccess.Entities;
using System.Linq.Expressions;

namespace mpit.DataAccess.Repositories
{
    public abstract class BaseRepository<TDbContext, T>(
        TDbContext context,
        IMapper mapper)
            where TDbContext : BaseDbContext
            where T : Entity
    {
        protected readonly IMapper Mapper = mapper;
        protected readonly TDbContext Context = context;
        protected DbSet<T> Entities => Context.Set<T>();

        protected async Task AddAsync(T entity)
        {
            await Entities.AddAsync(entity);
        }

        protected async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await Entities.AddRangeAsync(entities);
        }

        protected IQueryable<T> Find(Expression<Func<T, bool>> expression) => 
            Entities.Where(expression).AsQueryable();

        protected IQueryable<T> FindById(Guid id) =>
            Find(x => x.Id == id);

        protected async Task SaveChangesAsync() => 
            await Context.SaveChangesAsync();

        public async Task DeleteByIdAsync(Guid id) => 
            await FindById(id).ExecuteDeleteAsync();

        protected void Remove(T entity)
        {
            Entities.Remove(entity);
        }

        protected void RemoveRange(IEnumerable<T> entities)
        {
            Entities.RemoveRange(entities);
        }
    }
}
