using AutoMapper;
using PSI.TI.GestaoEscolar.Application.Notification;
using PSI.TI.GestaoEscolar.Application.ViewModels;
using PSI.TI.GestaoEscolar.Domain.Interfaces.Repository;
using PSI.TI.GestaoEscolar.Domain.Models;
using PSI.TI.GestaoEscolar.Domain.Models.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSI.TI.GestaoEscolar.Application.Services
{
    public class TurmaService : BaseService, ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly IMapper _mapper;

        public TurmaService(INotificador notificator,
            ITurmaRepository turmaRepository,
            IMapper mapper) : base(notificator)
        {
            _turmaRepository = turmaRepository;
            _mapper = mapper;
        }

        public async Task<TurmaViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<TurmaViewModel>(await _turmaRepository.ObterPorId(id));
        }

        public async Task<IEnumerable<TurmaViewModel>> ObterTodas()
        {
            return _mapper.Map<IEnumerable<TurmaViewModel>>(await _turmaRepository.ObterTodas());
        }

        public async Task Adicionar(TurmaViewModel turmaViewModel)
        {
            var turma = _mapper.Map<Turma>(turmaViewModel);
            if (!ExecutarValidacao(new TurmaValidation(), turma)) return;

            _turmaRepository.Adicionar(turma);
            await _turmaRepository.UnitOfWork.Commit();
        }

        public Task Atualizar(TurmaViewModel turmaViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task Remover(Guid id)
        {
            _turmaRepository.Remover(id);
            await _turmaRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _turmaRepository?.Dispose();
        }
    }
}