using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PSI.TI.GestaoEscolar.Domain.Interfaces.Repository;
using PSI.TI.GestaoEscolar.Domain.Models;

namespace PSI.TI.GestaoEscolar.Data.Repository
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly Context _context;
        public IUnitOfWork UnitOfWork => _context;

        public ProfessorRepository(Context context)
        {
            _context = context;
        }

        public async Task<Professor> ObterPorId(Guid id)
        {
            return await _context.Professores.FindAsync(id);
        }

        public async Task<IEnumerable<Professor>> ObterTodos()
        {
            return await _context.Professores.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Professor>> Buscar(Expression<Func<Professor, bool>> condicao)
        {
            return await _context.Professores.AsNoTracking().Where(condicao).ToListAsync();
        }

        public void Adicionar(Professor professor)
        {
            _context.Professores.Add(professor);
        }

        public void Atualizar(Professor professor)
        {
            _context.Professores.Update(professor);
        }

        public void Remover(Guid id)
        {
            _context.Professores.Remove(ObterPorId(id).Result);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}