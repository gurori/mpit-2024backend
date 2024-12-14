using mpit.Application.Intefaces.Auth;
using mpit.Application.Intefaces.Repositories;
using mpit.Application.Intefaces.Services;
using mpit.Core.DTO.User;
using mpit.Core.Exceptions;
using mpit.Core.Models;

namespace mpit.Application.Services
{
    public sealed class UserService(
        IUserRepository userRepo,
        IPasswordHasher passwordHasher)
            : IUserService
    {
        private readonly IUserRepository _userRepo = userRepo;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;

        public Task<ICollection<User>> GetAllAsync()
        {
            return _userRepo.GetAllAsync();
        }

        public async Task<User> GetAsync(Guid id)
        {
            var user = await _userRepo.GetByIdAsync(id)
                ?? throw new NotFoundException("Пользователь не найден");

            return user;
        }

        public async Task<Guid> RegisterAsync(CreateUserRequest request)
        {
            string passwordHash = _passwordHasher.Generate(request.Password);

            Guid? id = await _userRepo.TryCreateAsync(
                request.Email,
                request.FirstName,
                passwordHash,
                request.Role);

            return id is null ? throw new ConflictException("Данный пользователь уже существует") : (Guid)id;
        }
    }
}
