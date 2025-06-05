using AuthService.Models;
using AuthService.DTO;
using AuthService.Services;

namespace AuthService.Interfaces
{


    public interface IAuthServiceInterface
    {
        Task<LoginResponseDTO?> Login(LoginRequestDTO request);
        string GenerateJwtToken(User user);
        Task<bool> ValidateTokenAsync(string token);
    }
}