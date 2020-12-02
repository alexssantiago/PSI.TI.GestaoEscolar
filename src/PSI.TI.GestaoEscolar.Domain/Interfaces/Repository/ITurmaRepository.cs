using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PSI.TI.GestaoEscolar.Domain.Models;

namespace PSI.TI.GestaoEscolar.Domain.Interfaces.Repository
{
    public interface ITurmaRepository : IRepository<Turma>
    {
        Task<Turma> ObterPorId(Guid id);
        Task<IEnumerable<Turma>> ObterTodas();
        Task<IEnumerable<Turma>> Buscar(Expression<Func<Turma, bool>> condicao);

        void Adicionar(Turma turma);
        void Atualizar(Turma turma);
        void Remover(Guid id);
    }
}