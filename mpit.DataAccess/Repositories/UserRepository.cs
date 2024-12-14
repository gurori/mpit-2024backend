using AutoMapper;
using Microsoft.EntityFrameworkCore;
using mpit.Application.Intefaces.Repositories;
using mpit.Core.DTO.User;
using mpit.Core.Models;
using mpit.DataAccess.DbContexts;
using mpit.DataAccess.Entities;

namespace mpit.DataAccess.Repositories
{
    public sealed class UserRepository(ApplicationDbContext context, IMapper mapper)
            : BaseRepository<ApplicationDbContext, UserEntity>(context, mapper), 
                IUserRepository
    {

        public async Task<ICollection<User>> GetAllAsync()
        {
            var userEntities = await Entities.ToArrayAsync();

            return Mapper.Map<ICollection<User>>(userEntities);
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            var user = await Find(x => x.Id == id)
                .AsNoTracking()
                .Include(x => x.Vacancies)
                .FirstOrDefaultAsync();

            if (user is null) return null;

            return Mapper.Map<User>(user);
        }

        public async Task<Guid?> TryCreateAsync(string email, string firstName, string passwordHash, string role)
        {
            bool isUserExist = await Entities
                .AsNoTracking()
                .AnyAsync(x => x.Email == email);

            if (isUserExist) return null;

            UserEntity userEntity = new UserEntity()
            {
                Email = email,
                FirstName = firstName,
                PasswordHash = passwordHash,
                Role = role
            };

            await AddAsync(userEntity);
            await SaveChangesAsync();
            return userEntity.Id;
        }
    }
}
