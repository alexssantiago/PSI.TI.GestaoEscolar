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
using PSI.TI.GestaoEscolar.Domain.DomainObjects;

namespace PSI.TI.GestaoEscolar.Application.Services
{
    public class ResponsavelService : BaseService, IResponsavelService
    {
        private readonly IResponsavelRepository _responsavelRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public ResponsavelService(INotificador notificator,
                                  IResponsavelRepository responsavelRepository,
                                  IAlunoRepository alunoRepository,
                                  IMapper mapper) : base(notificator)
        {
            _responsavelRepository = responsavelRepository;
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }

        public async Task<ResponsavelViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<ResponsavelViewModel>(await _responsavelRepository.ObterPorId(id));
        }

        public async Task<ResponsavelViewModel> ObterResponsavelDependentesPorId(Guid id)
        {
            return _mapper.Map<ResponsavelViewModel>(await _responsavelRepository.ObterResponsavelDependentesPorId(id));
        }

        public async Task<IEnumerable<ResponsavelViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ResponsavelViewModel>>(await _responsavelRepository.ObterTodos());
        }

        public async Task Adicionar(ResponsavelViewModel responsavelViewModel)
        {
            var responsavel = _mapper.Map<Responsavel>(responsavelViewModel);
            if (!ExecutarValidacao(new ResponsavelValidation(), responsavel)) return;

            if (_responsavelRepository.Buscar(r => r.Cpf == responsavel.Cpf).Result.Any())
            {
                Notificar("Já existe um responsável cadastrado com o CPF informado.");
                return;
            }

            _responsavelRepository.Adicionar(responsavel);
            await _responsavelRepository.UnitOfWork.Commit();
        }

        public async Task Atualizar(ResponsavelViewModel responsavelViewModel)
        {
            var responsavel = _mapper.Map<Responsavel>(responsavelViewModel);
            if (!ExecutarValidacao(new ResponsavelValidation(), responsavel)) return;

            if (_responsavelRepository.Buscar(r => r.Cpf == responsavel.Cpf && r.Id != responsavel.Id).Result.Any())
            {
                Notificar("Já existe um responsável cadastrado com este CPF informado.");
                return;
            }

            _responsavelRepository.Atualizar(responsavel);
            await _responsavelRepository.UnitOfWork.Commit();
        }

        public async Task Remover(Guid id)
        {
            _responsavelRepository.Remover(id);
            await _responsavelRepository.UnitOfWork.Commit();
        }

        public async Task AdicionarDependente(AlunoViewModel alunoViewModel)
        {
            var aluno = _mapper.Map<Aluno>(alunoViewModel);
            if (!ExecutarValidacao(new AlunoValidation(), aluno)) return;

            var responsavel = await _responsavelRepository.ObterResponsavelDependentesPorId(aluno.ResponsavelId);

            if (responsavel == null)
            {
                Notificar("Responsável não cadastrado!");
                return;
            }

            try
            {
                responsavel.AdicionarDependente(aluno);
            }
            catch (DomainException e)
            {
                Notificar(e.Message);
                return;
            }

            _alunoRepository.Adicionar(aluno);
            await _alunoRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _responsavelRepository?.Dispose();
        }
    }
}