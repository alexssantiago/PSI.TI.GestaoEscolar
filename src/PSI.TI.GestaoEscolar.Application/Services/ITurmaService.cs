using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PSI.TI.GestaoEscolar.Application.ViewModels;

namespace PSI.TI.GestaoEscolar.Application.Services
{
    public interface ITurmaService : IDisposable
    {
        Task<TurmaViewModel> ObterPorId(Guid id);
        Task<IEnumerable<TurmaViewModel>> ObterTodas();

        Task Adicionar(TurmaViewModel turmaViewModel);
        Task Atualizar(TurmaViewModel turmaViewModel);
        Task Remover(Guid id);
    }
}