using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteSimonides2.Models;
using TesteSimonides2.Repositories;
using TesteSimonides2.Repositories.Interfaces;
using TesteSimonides2.Services;

namespace TesteSimonides2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GerenteController : ControllerBase
    {
        private readonly IGerenteRepository _objeto;

        public GerenteController(IGerenteRepository GerenteRepository)
        {
            _objeto = GerenteRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gerente>> BuscarPorId(int id)
        {
            Gerente Gerente = await _objeto.BuscarPorId(id);
            return Ok(Gerente);
        }

        [HttpPost]
        public async Task<ActionResult<Gerente>> Cadastrar([FromBody] Gerente Gerente)
        {
            
            var GerenteNovo = await _objeto.Adicionar(Gerente);
            return Ok(GerenteNovo);
        }

        [HttpGet]
        [Route("authenticated")]
        public string Authenticated() => string.Format("Autenticado - {0}", User.Identity.Name);

    }
}
