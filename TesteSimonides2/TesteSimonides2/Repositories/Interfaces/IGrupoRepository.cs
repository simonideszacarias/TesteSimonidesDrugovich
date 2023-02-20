using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using TesteSimonides2.Models;

namespace TesteSimonides2.Repositories.Interfaces
{
    public interface IGrupoRepository
    {
        List<Grupo> BuscarPorTodos();
        Task <Grupo> BuscarPorId(int codigo);
        Task<Grupo> Adicionar(Grupo grupo);
        Task<Grupo> Atualizar(Grupo grupo, int codigo);
        Task<bool> Apagar(int codigo);
    }
}
