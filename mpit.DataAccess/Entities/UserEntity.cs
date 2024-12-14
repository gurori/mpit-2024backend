
namespace mpit.DataAccess.Entities
{
    public class UserEntity : Entity
    {
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

        public ICollection<VacancyEntity> Vacancies { get; set; } = [];
        public ICollection<Guid> VacancyIds { get; set; } = [];
    }
}
