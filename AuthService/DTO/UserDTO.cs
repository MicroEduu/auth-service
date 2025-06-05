using AuthService.Enum;

namespace AuthService.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public ERole Role { get; set; } 

        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
