using AutoMapper;
using PSI.TI.GestaoEscolar.Application.Notification;
using PSI.TI.GestaoEscolar.Application.ViewModels;
using PSI.TI.GestaoEscolar.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSI.TI.GestaoEscolar.Application.Services
{
    public class AlunoService : BaseService, IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public AlunoService(INotificador notificator, 
                            IAlunoRepository alunoRepository, 
                            IMapper mapper) : base(notificator)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }

        public async Task<AlunoViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<AlunoViewModel>(await _alunoRepository.ObterPorId(id));
        }

        public async Task<IEnumerable<AlunoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<AlunoViewModel>>(await _alunoRepository.ObterTodos());
        }

        public void Dispose()
        {
            _alunoRepository?.Dispose();
        }
    }
}