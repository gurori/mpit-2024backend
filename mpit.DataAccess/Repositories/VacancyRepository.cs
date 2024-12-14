using AutoMapper;
using Microsoft.EntityFrameworkCore;
using mpit.Application.Intefaces.Services;
using mpit.Core.DTO;
using mpit.Core.Models;
using mpit.DataAccess.DbContexts;
using mpit.DataAccess.Entities;

namespace mpit.DataAccess.Repositories
{
    public sealed class VacancyRepository(
        ApplicationDbContext context,
        IMapper mapper)
            : BaseRepository<ApplicationDbContext, VacancyEntity>(context, mapper),
                IVacancyRepository
    {
        public async Task CreateAsync(CreateVacancyRequest request)
        {
            UserEntity? employer = await Context.Users
                .Where(x => x.Id == request.EmployerId)
                .FirstOrDefaultAsync();

            if (employer is null) return;

            VacancyEntity vacancyEntity = new()
            {
                Title = request.Title,
                Description = request.Description,
                Salary = request.Salary,
                EmployerId = request.EmployerId,
                Users = [employer]
            };

            await AddAsync(vacancyEntity);
            await SaveChangesAsync();
        }

        public async Task<ICollection<Vacancy>> GetAllAsync()
        {
            var entities = await Entities
                .AsNoTracking()
                .Include(x => x.Users) // ???
                .ToListAsync();

            return Mapper.Map<Vacancy[]>(entities);
        }

        public async Task<Vacancy?> GetByIdAsync(Guid id)
        {
            var vacancy = await FindById(id).AsNoTracking().FirstOrDefaultAsync();

            if (vacancy is null) return null;

            return Mapper.Map<Vacancy>(vacancy);
        }
    }
}
