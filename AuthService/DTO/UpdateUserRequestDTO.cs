using AuthService.Enum;

namespace AuthService.DTO
{
    public class UpdateUserRequestDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public ERole? RoleId { get; set; }
        public bool IsActive { get; set; }
    }
}
