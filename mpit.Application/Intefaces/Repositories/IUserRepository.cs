using mpit.Core.Models;

namespace mpit.Application.Intefaces.Repositories
{
    public interface IUserRepository
    {
        public Task<ICollection<User>> GetAll();
    }
}
