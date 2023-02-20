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
    public class GrupoController : ControllerBase
    {
        private readonly IGrupoRepository _objeto;

        public GrupoController(IGrupoRepository grupoRepository)
        {
            _objeto = grupoRepository;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "NivelUm, NivelDois")]
        public async Task<ActionResult<Grupo>> BuscarPorId(int id)
        {
            Grupo grupo = await _objeto.BuscarPorId(id);
            return Ok(grupo);
        }

        [HttpGet]
        [Route("buscarTodos")]
        [Authorize(Roles = "NivelUm, NivelDois")]
        public async Task<ActionResult<Grupo>> BuscarTodos()
        {
            List<Grupo> cliente = _objeto.BuscarPorTodos();
            return Ok(cliente);
        }

        [HttpPost]
        [Authorize(Roles = "NivelDois")]
        public async Task<ActionResult<Grupo>> Cadastrar([FromBody] Grupo grupo)
        {

            var grupoNovo = await _objeto.Adicionar(grupo);
            return Ok(grupoNovo);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "NivelDois")]
        public async Task<ActionResult<Grupo>> Excluir(int id)
        {

            var grupoNovo = await _objeto.Apagar(id);
            return Ok(grupoNovo);
        }

    }
}
