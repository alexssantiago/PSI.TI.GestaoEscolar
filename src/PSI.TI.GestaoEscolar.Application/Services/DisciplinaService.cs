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
    public class DisciplinaService : BaseService, IDisciplinaService
    {
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly IMapper _mapper;

        public DisciplinaService(INotificador notificator,
            IDisciplinaRepository disciplinaRepository,
            IMapper mapper) : base(notificator)
        {
            _disciplinaRepository = disciplinaRepository;
            _mapper = mapper;
        }
        public async Task<DisciplinaViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<DisciplinaViewModel>(await _disciplinaRepository.ObterPorId(id));
        }

        public async Task<IEnumerable<DisciplinaViewModel>> ObterTodas()
        {
            return _mapper.Map<IEnumerable<DisciplinaViewModel>>(await _disciplinaRepository.ObterTodas());
        }

        public async Task Adicionar(DisciplinaViewModel disciplinaViewModel)
        {
            var disciplina = _mapper.Map<Disciplina>(disciplinaViewModel);
            if (!ExecutarValidacao(new DisciplinaValidation(), disciplina)) return;

            _disciplinaRepository.Adicionar(disciplina);
            await _disciplinaRepository.UnitOfWork.Commit();
        }

        public Task Atualizar(DisciplinaViewModel disciplinaViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task Remover(Guid id)
        {
            _disciplinaRepository.Remover(id);
            await _disciplinaRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _disciplinaRepository?.Dispose();
        }
    }
}