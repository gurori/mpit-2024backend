using mpit.Core.DTO.User;

namespace mpit.Core.Models
{
    public sealed class Vacancy
    {
        public Vacancy()
        {
            
        }
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Salary { get; private set; }

        public ICollection<UserDto> Users { get; private set; }
        public ICollection<Guid> UserIds { get; private set; }
        public Guid? EmployerId { get; private set; }
    }
}
