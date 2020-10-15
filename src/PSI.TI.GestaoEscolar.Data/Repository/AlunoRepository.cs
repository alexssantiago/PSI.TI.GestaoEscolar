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
    public class AlunoRepository : IAlunoRepository
    {
        private readonly Context _context;
        public IUnitOfWork UnitOfWork => _context;

        public AlunoRepository(Context context)
        {
            _context = context;
        }

        public async Task<Aluno> ObterPorId(Guid id)
        {
            return await _context.Alunos.FindAsync(id);
        }

        public async Task<IEnumerable<Aluno>> ObterTodos()
        {
            return await _context.Alunos.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Aluno>> Buscar(Expression<Func<Aluno, bool>> condicao)
        {
            return await _context.Alunos.AsNoTracking().Where(condicao).ToListAsync();
        }

        public void Adicionar(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
        }

        public void Atualizar(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
        }

        public void Remover(Guid id)
        {
            _context.Alunos.Remove(ObterPorId(id).Result);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}