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

        public async Task Adicionar(AlunoViewModel alunoViewModel)
        {
            var aluno = _mapper.Map<Aluno>(alunoViewModel);
            if (!ExecutarValidacao(new AlunoValidation(), aluno)) return;

            if (_alunoRepository.Buscar(r => r.Cpf == aluno.Cpf).Result.Any())
            {
                Notificar("Já existe um aluno cadastrado com o CPF informado.");
                return;
            }

            _alunoRepository.Adicionar(aluno);
            await _alunoRepository.UnitOfWork.Commit();
        }

        public async Task Atualizar(AlunoViewModel alunoViewModel)
        {
            var aluno = _mapper.Map<Aluno>(alunoViewModel);
            if (!ExecutarValidacao(new AlunoValidation(), aluno)) return;

            if (_alunoRepository.Buscar(r => r.Cpf == aluno.Cpf && r.Id != aluno.Id).Result.Any())
            {
                Notificar("Já existe um aluno cadastrado com este CPF informado.");
                return;
            }

            _alunoRepository.Atualizar(aluno);
            await _alunoRepository.UnitOfWork.Commit();
        }

        public async Task Remover(Guid id)
        {
            _alunoRepository.Remover(id);
            await _alunoRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _alunoRepository?.Dispose();
        }
    }
}