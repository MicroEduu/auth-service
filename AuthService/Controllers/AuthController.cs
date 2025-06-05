using Microsoft.AspNetCore.Mvc;
using AuthService.Services;
using AuthService.DTO;
using AuthService.Interfaces;


namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServiceInterface _authService;

        public AuthController(IAuthServiceInterface authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            var result = await _authService.Login(request);

            if (result == null)
                return Unauthorized("Usuário ou senha inválidos");

            return Ok(result);
        }


    }
}
