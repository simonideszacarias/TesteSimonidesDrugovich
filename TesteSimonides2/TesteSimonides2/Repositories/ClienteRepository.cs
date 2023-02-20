using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteSimonides2.Data;
using TesteSimonides2.Models;
using TesteSimonides2.Repositories.Interfaces;

namespace TesteSimonides2.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Cliente> BuscarClientesPorGrupo(int codigoGrupo)
        {
            List<Cliente> listaClientes = new List<Cliente>();
            Cliente cliente = new Cliente();
            List<GrupoCliente> listaGrupoClientes = _context.GruposClientes.Where(w => w.GrupoCodigo == codigoGrupo).ToList();
            
            foreach(var grupo in listaGrupoClientes)
            {
                cliente = _context.Clientes.Where(w => w.Codigo == grupo.ClienteCodigo).FirstOrDefault();
                listaClientes.Add(cliente);
            }
            return listaClientes;
        }

        public async Task<Cliente> BuscarPorId(int codigo)
        {
            return await _context.Clientes.FirstOrDefaultAsync(x => x.Codigo == codigo);
        }

        async Task<Cliente> IClienteRepository.Adicionar(Cliente cliente)
        {
            
            await _context.Clientes.AddAsync(cliente);
            _context.SaveChanges();
            return cliente;
        }

        async Task<bool> IClienteRepository.Apagar(int codigo)
        {
            var objeto = await BuscarPorId(codigo);
            if (objeto == null)
            {
                throw new Exception($"Cliente para o ID:{codigo} não foi encontrado");
            }
            _context.Clientes.Remove(objeto);
            _context.SaveChanges();
            return true;
        }

        async Task<Cliente> IClienteRepository.Atualizar(Cliente cliente, int codigo)
        {
            var objeto = await BuscarPorId(codigo);
            if (objeto == null)
            {
                throw new Exception($"Cliente para o ID:{codigo} não foi encontrado");
            }
            objeto.Nome = cliente.Nome;
            return objeto;

        }
    }
}
