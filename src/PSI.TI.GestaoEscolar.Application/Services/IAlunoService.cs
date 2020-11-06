using PSI.TI.GestaoEscolar.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSI.TI.GestaoEscolar.Application.Services
{
    public interface IAlunoService : IDisposable
    {
        Task<AlunoViewModel> ObterPorId(Guid id);
        Task<IEnumerable<AlunoViewModel>> ObterTodos();
    }
}