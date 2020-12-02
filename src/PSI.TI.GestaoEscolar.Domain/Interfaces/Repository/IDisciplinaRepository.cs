using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PSI.TI.GestaoEscolar.Domain.Models;

namespace PSI.TI.GestaoEscolar.Domain.Interfaces.Repository
{
    public interface IDisciplinaRepository : IRepository<Disciplina>
    {
        Task<Disciplina> ObterPorId(Guid id);
        Task<IEnumerable<Disciplina>> ObterTodas();
        Task<IEnumerable<Disciplina>> Buscar(Expression<Func<Disciplina, bool>> condicao);

        void Adicionar(Disciplina disciplina);
        void Atualizar(Disciplina disciplina);
        void Remover(Guid id);
    }
}