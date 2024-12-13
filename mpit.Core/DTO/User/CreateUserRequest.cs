namespace mpit.Core.DTO.User
{
    public record CreateUserRequest(
        string Email,
        string Password,
        string FirstName,
        string Role);
}
