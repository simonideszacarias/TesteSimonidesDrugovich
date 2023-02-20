using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using TesteSimonides2.Models;

namespace TesteSimonides2.Repositories.Interfaces
{
    public interface IGrupoClienteRepository
    {
        Task <GrupoCliente> BuscarPorId(int codigo);
        Task<GrupoCliente> Adicionar(GrupoCliente grupo);
        Task<GrupoCliente> Atualizar(GrupoCliente grupo, int codigo);
        Task<bool> Apagar(int codigo);
    }
}
