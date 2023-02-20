using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteSimonides2.Data;
using TesteSimonides2.Models;
using TesteSimonides2.Repositories.Interfaces;

namespace TesteSimonides1.Repositories
{
    public class GrupoClienteRepository : IGrupoClienteRepository
    {
        private readonly AppDbContext _context;

        public GrupoClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GrupoCliente> BuscarPorId(int codigo)
        {
            return await _context.GruposClientes.FirstOrDefaultAsync(x => x.Codigo == codigo);
        }

        async Task<GrupoCliente> IGrupoClienteRepository.Adicionar(GrupoCliente grupo)
        {
            var grupoCliente = _context.GruposClientes.Where(w => w.ClienteCodigo == grupo.ClienteCodigo && w.GrupoCodigo == grupo.GrupoCodigo).FirstOrDefault();
            if (grupoCliente != null)
            {
                throw new Exception($"Cliente já está cadastrado em um grupo");
            }
            
            await _context.GruposClientes.AddAsync(grupo);
            _context.SaveChanges();
            return grupo;
        }

        async Task<bool> IGrupoClienteRepository.Apagar(int codigo)
        {
            var objeto = await BuscarPorId(codigo);
            if (objeto == null)
            {
                throw new Exception($"Grupo para o ID:{codigo} não foi encontrado");
            }
            _context.GruposClientes.Remove(objeto);
            _context.SaveChanges();
            return true;
        }

        async Task<GrupoCliente> IGrupoClienteRepository.Atualizar(GrupoCliente grupo, int codigo)
        {
            var objeto = await BuscarPorId(codigo);
            if (objeto == null)
            {
                throw new Exception($"Grupo para o ID:{codigo} não foi encontrado");
            }
            objeto.ClienteCodigo = grupo.ClienteCodigo;
            objeto.GrupoCodigo = grupo.GrupoCodigo;
            return objeto;

        }
    }
}
