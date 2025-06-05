using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using AuthService.Services;
using AuthService.DTO;


namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateUserRequestDTO request)
        {
            try
            {
                _userService.Create(request);

                return Ok("Conta inserida com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    error = "Erro ao criar conta",
                    message = e.Message
                });
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateUserRequestDTO dto)
        {
           
            try
            {
                _userService.Update(id, dto);

                return Ok("Usuário alterada com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetUsers()
        {
            try
            {
                var users = _userService.GetUsers();

                return Ok(users);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("/api/[controller]/{id}")]
        [Authorize]
        public IActionResult getUserById(int id)
        {
            try
            {
                var user = _userService.GetUserById(id);

                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("/api/[Controller]/Delete/{id}")]
        [Authorize]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                _userService.DeleteUser(id);

                return Ok("Usuário excluído com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPatch("/api/[Controller]/Deactivate/{id}")]
        [Authorize]
        public IActionResult Desactivate([FromRoute] int id)
        {
            try
            {
                _userService.Desactivate(id);
                return Ok("Usuário inativado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
