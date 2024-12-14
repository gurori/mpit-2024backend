namespace mpit.Core.DTO
{
    public record CreateVacancyRequest(
        string Title,
        string Description,
        decimal Salary,
        Guid EmployerId);
}
