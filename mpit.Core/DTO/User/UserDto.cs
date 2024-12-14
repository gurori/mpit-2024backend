namespace mpit.Core.DTO.User
{
    public record UserDto(
        Guid Id,
        string Email,
        string FirstName,
        string Role);
}
