using AutoMapper;
using PSI.TI.GestaoEscolar.Application.Notification;
using PSI.TI.GestaoEscolar.Application.ViewModels;
using PSI.TI.GestaoEscolar.Domain.Interfaces.Repository;
using PSI.TI.GestaoEscolar.Domain.Models;
using PSI.TI.GestaoEscolar.Domain.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSI.TI.GestaoEscolar.Application.Services
{
    public class ProfessorService : BaseService, IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IMapper _mapper;

        public ProfessorService(INotificador notificator,
            IProfessorRepository responsavelRepository,
            IMapper mapper) : base(notificator)
        {
            _professorRepository = responsavelRepository;
            _mapper = mapper;
        }

        public async Task<ProfessorViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<ProfessorViewModel>(await _professorRepository.ObterPorId(id));
        }

        public async Task<IEnumerable<ProfessorViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProfessorViewModel>>(await _professorRepository.ObterTodos());
        }

        public async Task Adicionar(ProfessorViewModel professorViewModel)
        {
            var professor = _mapper.Map<Professor>(professorViewModel);
            if (!ExecutarValidacao(new ProfessorValidation(), professor)) return;

            if (_professorRepository.Buscar(r => r.Cpf == professor.Cpf).Result.Any())
            {
                Notificar("Já existe um professor cadastrado com o CPF informado.");
                return;
            }

            _professorRepository.Adicionar(professor);
            await _professorRepository.UnitOfWork.Commit();
        }

        public Task Atualizar(ProfessorViewModel professorViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task Remover(Guid id)
        {
            _professorRepository.Remover(id);
            await _professorRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _professorRepository?.Dispose();
        }
    }
}