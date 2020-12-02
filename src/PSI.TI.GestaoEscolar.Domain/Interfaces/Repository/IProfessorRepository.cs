using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PSI.TI.GestaoEscolar.Domain.Models;

namespace PSI.TI.GestaoEscolar.Domain.Interfaces.Repository
{
    public interface IProfessorRepository : IRepository<Professor>
    {
        Task<Professor> ObterPorId(Guid id);
        Task<IEnumerable<Professor>> ObterTodos();
        Task<IEnumerable<Professor>> Buscar(Expression<Func<Professor, bool>> condicao);

        void Adicionar(Professor professor);
        void Atualizar(Professor professor);
        void Remover(Guid id);
    }
}