using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using TesteSimonides2.Models;

namespace TesteSimonides2.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        List<Cliente> BuscarClientesPorGrupo(int codigoGrupo);
        Task <Cliente> BuscarPorId(int codigo);
        Task<Cliente> Adicionar(Cliente cliente);
        Task<Cliente> Atualizar(Cliente cliente, int codigo);
        Task<bool> Apagar(int codigo);
    }
}
