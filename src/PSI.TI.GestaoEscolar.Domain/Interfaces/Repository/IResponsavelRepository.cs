using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PSI.TI.GestaoEscolar.Domain.Models;

namespace PSI.TI.GestaoEscolar.Domain.Interfaces.Repository
{
    public interface IResponsavelRepository : IRepository<Responsavel>
    {
        Task<Responsavel> ObterPorId(Guid id);
        Task<Responsavel> ObterResponsavelDependentesPorId(Guid id);
        Task<IEnumerable<Responsavel>> ObterTodos();
        Task<IEnumerable<Responsavel>> Buscar(Expression<Func<Responsavel, bool>> condicao);

        void Adicionar(Responsavel responsavel);
        void Atualizar(Responsavel responsavel);
        void Remover(Guid id);
    }
}