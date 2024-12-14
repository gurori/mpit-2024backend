namespace mpit.Core.DTO
{
    public record VacancyDto(
        Guid Id,
        string Title,
        string Description,
        decimal Salary,
        Guid EmployerId,
        ICollection<Guid> UserIds);
}
