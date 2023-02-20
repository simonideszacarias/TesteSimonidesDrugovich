using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteSimonides1.Repositories;
using TesteSimonides2.Models;
using TesteSimonides2.Repositories.Interfaces;

namespace TesteSimonides2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoClienteController : ControllerBase
    {
        private readonly IGrupoClienteRepository _objeto;
        
        public GrupoClienteController(IGrupoClienteRepository grupoClienteRepository)
        {
            _objeto = grupoClienteRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoCliente>> BuscarPorId(int id)
        {
            GrupoCliente grupoCliente = await _objeto.BuscarPorId(id);
            return Ok(grupoCliente);
        }

        [HttpPost]
        
        public async Task<ActionResult<GrupoCliente>> Cadastrar([FromBody] GrupoCliente grupoCliente)
        {
            var grupoClienteNovo = await _objeto.Adicionar(grupoCliente);
            return Ok(grupoClienteNovo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GrupoCliente>> Excluir(int id)
        {

            var grupoClienteNovo = await _objeto.Apagar(id);
            return Ok(grupoClienteNovo);
        }

    }
}
