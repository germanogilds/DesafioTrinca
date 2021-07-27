
using Churrasco.Domain.Entities;
using Churrasco.Domain.Entities.Interfaces;
using Churrasco.Domain.Services.Interfaces;
using Churrasco.WebApi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Churrasco.WebApi.Controllers
{
    [ApiController]
    [Route("")]
    public class UsersController : ControllerBase
    {
        private IUsuarioService _usuarioServiceService;

        public UsersController(IUsuarioService usuarioService)
        {
            _usuarioServiceService = usuarioService;
        }

        [HttpPost("auth")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _usuarioServiceService.Authenticate(model.NomeDeUsuario, model.Senha);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet("obter-usuarios")]
        public IActionResult GetAll()
        {
            var users = _usuarioServiceService.GetAll();
            return Ok(users);
        }
    }
}
