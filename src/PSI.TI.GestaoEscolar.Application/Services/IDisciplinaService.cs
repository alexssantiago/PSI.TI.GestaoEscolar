using PSI.TI.GestaoEscolar.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSI.TI.GestaoEscolar.Application.Services
{
    public interface IDisciplinaService : IDisposable
    {
        Task<DisciplinaViewModel> ObterPorId(Guid id);
        Task<IEnumerable<DisciplinaViewModel>> ObterTodas();

        Task Adicionar(DisciplinaViewModel disciplinaViewModel);
        Task Atualizar(DisciplinaViewModel disciplinaViewModel);
        Task Remover(Guid id);
    }
}