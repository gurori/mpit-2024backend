namespace mpit.DataAccess.Entities
{
    public sealed class VacancyEntity : Entity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Salary { get; set; }

        public ICollection<UserEntity> Users { get; set; } = [];
        public ICollection<Guid> UserIds { get; set; } = [];
        public Guid? EmployerId { get; set; } = null;
    }
}
