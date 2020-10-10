using PSI.TI.GestaoEscolar.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSI.TI.GestaoEscolar.Application.Services
{
    public interface IResponsavelService : IDisposable
    {
        Task<ResponsavelViewModel> ObterPorId(Guid id);
        Task<IEnumerable<ResponsavelViewModel>> ObterTodos();

        Task Adicionar(ResponsavelViewModel responsavelViewModel);
        Task Atualizar(ResponsavelViewModel responsavelViewModel);
        Task Remover(Guid id);

        Task AdicionarDependente(AlunoViewModel alunoViewModel);
    }
}