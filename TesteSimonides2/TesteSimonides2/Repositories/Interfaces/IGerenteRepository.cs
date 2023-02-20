using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using TesteSimonides2.Models;

namespace TesteSimonides2.Repositories.Interfaces
{
    public interface IGerenteRepository
    {
        Task<Gerente> BuscarPorEmail(string email);
        Task <Gerente> BuscarPorId(int codigo);
        Task<Gerente> Adicionar(Gerente gerente);
        Task<Gerente> Atualizar(Gerente gerente, int codigo);
        Task<bool> Apagar(int codigo);
    }
}
