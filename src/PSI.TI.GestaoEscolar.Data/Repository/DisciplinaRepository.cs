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
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly Context _context;
        public IUnitOfWork UnitOfWork => _context;

        public DisciplinaRepository(Context context)
        {
            _context = context;
        }

        public async Task<Disciplina> ObterPorId(Guid id)
        {
            return await _context.Disciplinas.FindAsync(id);
        }

        public async Task<IEnumerable<Disciplina>> ObterTodas()
        {
            return await _context.Disciplinas.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Disciplina>> Buscar(Expression<Func<Disciplina, bool>> condicao)
        {
            return await _context.Disciplinas.AsNoTracking().Where(condicao).ToListAsync();
        }

        public void Adicionar(Disciplina disciplina)
        {
            _context.Disciplinas.Add(disciplina);
        }

        public void Atualizar(Disciplina disciplina)
        {
            _context.Disciplinas.Update(disciplina);
        }

        public void Remover(Guid id)
        {
            _context.Disciplinas.Remove(ObterPorId(id).Result);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}