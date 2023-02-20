using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TesteSimonides2.Models;
using TesteSimonides2.Repositories;
using TesteSimonides2.Repositories.Interfaces;
using TesteSimonides2.Services;

namespace TesteSimonides2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IGerenteRepository _objeto;
        public LoginController(IGerenteRepository GerenteRepository)
        {
            _objeto = GerenteRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authentificate([FromBody] User model)
        {
            var user = LoginRepository.Get(model.Email, model.Password);
            if (user == null)
                return NotFound(new { message = "Usuário e ou senha invalidos!" });

            Gerente gerente = await _objeto.BuscarPorEmail(user.Email);

            var token = TokenService.GenerateToken(user, gerente.Nivel);

            //Garante que não passe a senha pelo token
            user.Password = "";

            return new
            {
                user = user,
                token = token
            };

        }
    }
}
