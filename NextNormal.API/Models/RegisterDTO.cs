namespace NextNormal.API.Models
{
    public sealed record RegisterDTO(
        string Email,
        string UserName,
        string FirstName,
        string LastName,
        string Password
        );
}
