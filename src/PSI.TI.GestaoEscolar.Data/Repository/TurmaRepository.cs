using Microsoft.EntityFrameworkCore;
using PSI.TI.GestaoEscolar.Domain.Interfaces.Repository;
using PSI.TI.GestaoEscolar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PSI.TI.GestaoEscolar.Data.Repository
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly Context _context;
        public IUnitOfWork UnitOfWork => _context;

        public TurmaRepository(Context context)
        {
            _context = context;
        }

        public async Task<Turma> ObterPorId(Guid id)
        {
            return await _context.Turmas
                .Include(t => t.Professor)
                .Include(t => t.Matriculas)
                .Include(t => t.DisciplinasOfertadas)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Turma>> ObterTodas()
        {
            return await _context.Turmas.AsNoTracking()
                .Include(t => t.Professor)
                .Include(t => t.Matriculas)
                .Include(t => t.DisciplinasOfertadas)
                .ToListAsync();
        }

        public async Task<IEnumerable<Turma>> Buscar(Expression<Func<Turma, bool>> condicao)
        {
            return await _context.Turmas.AsNoTracking().Where(condicao).ToListAsync();
        }

        public void Adicionar(Turma turma)
        {
            _context.Turmas.Add(turma);
        }

        public void Atualizar(Turma turma)
        {
            _context.Turmas.Update(turma);
        }

        public void Remover(Guid id)
        {
            _context.Turmas.Remove(ObterPorId(id).Result);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}