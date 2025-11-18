namespace NextNormal.API.Models
{
    public sealed record ChangePasswordDTO(
        Guid Id,
        string CurrentPassword,
        string NewPassword
        );
    
    
}
