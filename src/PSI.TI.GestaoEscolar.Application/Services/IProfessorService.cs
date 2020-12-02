using PSI.TI.GestaoEscolar.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSI.TI.GestaoEscolar.Application.Services
{
    public interface IProfessorService : IDisposable
    {
        Task<ProfessorViewModel> ObterPorId(Guid id);
        Task<IEnumerable<ProfessorViewModel>> ObterTodos();

        Task Adicionar(ProfessorViewModel professorViewModel);
        Task Atualizar(ProfessorViewModel professorViewModel);
        Task Remover(Guid id);
    }
}