using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PSI.TI.GestaoEscolar.Domain.Models;

namespace PSI.TI.GestaoEscolar.Domain.Interfaces.Repository
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        Task<Aluno> ObterPorId(Guid id);
        Task<IEnumerable<Aluno>> ObterTodos();

        void Adicionar(Aluno aluno);
        void Atualizar(Aluno aluno);
        void Remover(Guid id);
    }
}