using AutoMapper;
using Microsoft.EntityFrameworkCore;
using mpit.Application.Intefaces.Repositories;
using mpit.Core.Models;
using mpit.DataAccess.DbContexts;
using mpit.DataAccess.Entities;

namespace mpit.DataAccess.Repositories
{
    public sealed class UserRepository(UserDbContext context, IMapper mapper)
            : BaseRepository<UserDbContext, UserEntity>(context, mapper), 
                IUserRepository
    {

        public async Task<ICollection<User>> GetAll()
        {
            var userEntities = await Entities.ToArrayAsync();

            return Mapper.Map<ICollection<User>>(userEntities);
        }
    }
}
