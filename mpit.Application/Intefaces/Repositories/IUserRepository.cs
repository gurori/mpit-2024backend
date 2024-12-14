using mpit.Core.DTO.User;
using mpit.Core.Models;

namespace mpit.Application.Intefaces.Repositories
{
    public interface IUserRepository
    {
        public Task<ICollection<User>> GetAllAsync();
        public Task<User?> GetByIdAsync(Guid id);
        public Task<Guid?> TryCreateAsync(string email, string firstName, string passwordHash, string role);
    }
}
