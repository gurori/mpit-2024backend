using mpit.Application.Intefaces.Services;
using mpit.Core.DTO;
using mpit.Core.Exceptions;
using mpit.Core.Models;

namespace mpit.Application.Services
{
    public sealed class VacancyService(
        IVacancyRepository vacancyRepo)
    {
        private readonly IVacancyRepository _vacancyRepo = vacancyRepo;

        public async Task CreateAsync(CreateVacancyRequest request)
        {
            await _vacancyRepo.CreateAsync(request);
        }

        public async Task<ICollection<Vacancy>> GetAsync()
        {
            return await _vacancyRepo.GetAllAsync();
        }

        public async Task<Vacancy> GetAsync(Guid id)
        {
            var vacancy = await _vacancyRepo.GetByIdAsync(id)
                ?? throw new NotFoundException("Вакансия не найдена");
            
            return vacancy;
        }
    }
}
