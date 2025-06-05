using AuthService.Enum;

namespace AuthService.DTO
{
    public class CreateUserRequestDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public ERole Role { get; set; }
    }
}
