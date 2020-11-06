using PSI.TI.GestaoEscolar.Domain.DomainObjects;
using PSI.TI.GestaoEscolar.Domain.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using PSI.TI.GestaoEscolar.Domain.Models.Enums;

namespace PSI.TI.GestaoEscolar.Domain.Models
{
    public class Responsavel : Pessoa
    {
        public string GrauParentesco { get; }
        public string Ocupacao { get; private set; }
        public decimal Renda { get; private set; }
        public string NomeContato { get; private set; }
        public long TelefoneContato { get; private set; }

        private readonly List<Aluno> _dependentes;
        public IReadOnlyCollection<Aluno> Dependentes => _dependentes;

        //For EF
        protected Responsavel()
        {
            _dependentes = new List<Aluno>();
        }

        public Responsavel(string nome, long cpf, DateTime dataNascimento, string grauParentesco, string ocupacao, decimal renda, string nomeContato, long telefoneContato)
            : base(nome, cpf, dataNascimento)
        {
            GrauParentesco = grauParentesco;
            Ocupacao = ocupacao;
            Renda = renda;
            NomeContato = nomeContato;
            TelefoneContato = telefoneContato;
            _dependentes = new List<Aluno>();
        }

        public override bool EhValido() => new ResponsavelValidation().Validate(this).IsValid;

        public void AdicionarDependente(Aluno aluno)
        {
            if (aluno.ResponsavelId != Id) throw new DomainException("O aluno está associado a outro responsável.");

            if (PossuiDependente(aluno)) throw new DomainException("O responsável já possui um dependente cadastrado com o CPF informado.");

            aluno.TornarAtivo();
            _dependentes.Add(aluno);
        }

        public void AtualizarDependente(Aluno aluno)
        {
            if (!PossuiDependente(aluno)) throw new DomainException("O responsável não possui um dependente cadastrado com o CPF informado.");

            var dependenteExistente = Dependentes.FirstOrDefault(a => a.Id == aluno.Id);

            if (dependenteExistente == null) throw new DomainException("O dependente não está associado ao responsável.");

            if (aluno.Situacao != SituacaoAluno.Ativo && aluno.Situacao != SituacaoAluno.Matriculado) return;

            _dependentes.Remove(dependenteExistente);
            _dependentes.Add(aluno);
        }

        private bool PossuiDependente(Aluno aluno) => _dependentes.Any(d => d.Cpf == aluno.Cpf);
    }
}