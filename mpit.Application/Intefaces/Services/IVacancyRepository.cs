using mpit.Core.DTO;
using mpit.Core.Models;

namespace mpit.Application.Intefaces.Services
{
    public interface IVacancyRepository
    {
        public Task CreateAsync(CreateVacancyRequest request);
        public Task<ICollection<Vacancy>> GetAllAsync();
        public Task<Vacancy?> GetByIdAsync(Guid id);
    }
}
