namespace NextNormal.API.Models
{
    public sealed record ChangePassordWithTokenDTO(
        string Email,
        string NewPassword,
        string newToken
        );
   
}
