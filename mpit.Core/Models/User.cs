using mpit.Core.DTO;

namespace mpit.Core.Models
{
    public class User
    {
        public User() { }

        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public string Role { get; private set; }

        public ICollection<VacancyDto> Vacancies { get; private set; }
        public ICollection<Guid> VacancyIds { get; private set; }
    }
}
