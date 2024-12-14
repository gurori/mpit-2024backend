
using mpit.Core.DTO.User;
using mpit.Core.Models;

namespace mpit.Application.Intefaces.Services
{
    public interface IUserService
    {
        public Task<ICollection<User>> GetAllAsync();
        public Task<User> GetAsync(Guid id);
        public Task<Guid> RegisterAsync(CreateUserRequest request);
    }
}
