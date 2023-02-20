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
    public class GerenteRepository : IGerenteRepository
    {
        private readonly AppDbContext _context;

        public GerenteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Gerente> BuscarPorEmail(string email)
        {
            return await _context.Gerentes.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Gerente> BuscarPorId(int codigo)
        {
            return await _context.Gerentes.FirstOrDefaultAsync(x => x.Codigo == codigo);
        }

        async Task<Gerente> IGerenteRepository.Adicionar(Gerente gerente)
        {
            await _context.Gerentes.AddAsync(gerente);
            _context.SaveChanges();
            return gerente;
        }

        async Task<bool> IGerenteRepository.Apagar(int codigo)
        {
            var objeto = await BuscarPorId(codigo);
            if (objeto == null)
            {
                throw new Exception($"Gerente para o ID:{codigo} não foi encontrado");
            }
            _context.Gerentes.Remove(objeto);
            _context.SaveChanges();
            return true;
        }

        async Task<Gerente> IGerenteRepository.Atualizar(Gerente gerente, int codigo)
        {
            var objeto = await BuscarPorId(codigo);
            if (objeto == null)
            {
                throw new Exception($"Gerente para o ID:{codigo} não foi encontrado");
            }
            objeto.Nome = gerente.Nome;
            return objeto;

        }
    }
}
