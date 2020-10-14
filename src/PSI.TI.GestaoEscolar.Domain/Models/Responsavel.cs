using PSI.TI.GestaoEscolar.Domain.DomainObjects;
using PSI.TI.GestaoEscolar.Domain.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;

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
            if (aluno.ResponsavelId != Id) throw new DomainException($"O aluno {aluno.Nome} está associado a outro responsável.");

            if (PossuiDependente(aluno)) throw new DomainException($"O responsável {Nome} já possui o dependente {aluno.Nome}");

            aluno.TornarAtivo();
            _dependentes.Add(aluno);
        }

        private bool PossuiDependente(Aluno aluno) => _dependentes.Any(d => d.Cpf == aluno.Cpf);
    }
}