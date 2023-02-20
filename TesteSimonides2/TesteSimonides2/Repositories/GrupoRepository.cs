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
    public class GrupoRepository : IGrupoRepository
    {
        private readonly AppDbContext _context;

        public GrupoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Grupo> BuscarPorId(int codigo)
        {
            return await _context.Grupos.FirstOrDefaultAsync(x => x.Codigo == codigo);
        }

        public List<Grupo> BuscarPorTodos()
        {
            return  _context.Grupos.ToList();
        }

        async Task<Grupo> IGrupoRepository.Adicionar(Grupo grupo)
        {
           
            await _context.Grupos.AddAsync(grupo);
            _context.SaveChanges();
            return grupo;
        }

        async Task<bool> IGrupoRepository.Apagar(int codigo)
        {
            var objeto = await BuscarPorId(codigo);
            if (objeto == null)
            {
                throw new Exception($"Grupo para o ID:{codigo} não foi encontrado");
            }
            _context.Grupos.Remove(objeto);
            _context.SaveChanges();
            return true;
        }

        async Task<Grupo> IGrupoRepository.Atualizar(Grupo grupo, int codigo)
        {
            var objeto = await BuscarPorId(codigo);
            if (objeto == null)
            {
                throw new Exception($"Grupo para o ID:{codigo} não foi encontrado");
            }
            objeto.Nome = grupo.Nome;
            return objeto;

        }
    }
}
