using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteSimonides2.Models;
using TesteSimonides2.Repositories.Interfaces;

namespace TesteSimonides2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _objeto;
        
        public ClienteController(IClienteRepository clienteRepository)
        {
            _objeto = clienteRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> BuscarPorId(int id)
        {
            Cliente cliente = await _objeto.BuscarPorId(id);
            return Ok(cliente);
        }

        [HttpPost]
        [Authorize(Roles = "NivelDois")]
        public async Task<ActionResult<Cliente>> Cadastrar([FromBody] Cliente cliente)
        {
            
            var clienteNovo = await _objeto.Adicionar(cliente);
            return Ok(clienteNovo);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "NivelDois")]
        public async Task<ActionResult<Cliente>> Excluir(int id)
        {

            var clienteNovo = await _objeto.Apagar(id);
            return Ok(clienteNovo);
        }

        [HttpGet]
        [Route("buscarClientesPorGrupo")]
        public async Task<ActionResult<Cliente>> BuscarClientesPorGrupo([FromBody] ClienteJSON clienteJson)
        {
            List<Cliente> cliente = _objeto.BuscarClientesPorGrupo(clienteJson.codigoGrupo);
            return Ok(cliente);
        }

    }
}
