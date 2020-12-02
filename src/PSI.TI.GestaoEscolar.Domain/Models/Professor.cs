using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PSI.TI.GestaoEscolar.Domain.Models.Validations;

namespace PSI.TI.GestaoEscolar.Domain.Models
{
    public class Professor : Pessoa
    {
        public ICollection<string> Formacao { get; private set; }

        private readonly List<Turma> _turmas;
        public IReadOnlyCollection<Turma> Turmas => _turmas;

        // For EF
        protected Professor()
        {
            Formacao = new Collection<string>();
            _turmas = new List<Turma>();
        }

        public Professor(string nome, long cpf, DateTime dataNascimento, ICollection<string> formacao) : base(nome, cpf, dataNascimento)
        {
            Formacao = formacao;
            _turmas = new List<Turma>();
        }

        public override bool EhValido() => new ProfessorValidation().Validate(this).IsValid;
    }
}