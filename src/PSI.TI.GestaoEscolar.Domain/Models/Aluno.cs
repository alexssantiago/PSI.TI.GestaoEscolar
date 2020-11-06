using PSI.TI.GestaoEscolar.Domain.Models.Enums;
using PSI.TI.GestaoEscolar.Domain.Models.Validations;
using System;

namespace PSI.TI.GestaoEscolar.Domain.Models
{
    public class Aluno : Pessoa
    {
        public Guid Matricula { get; private set; }
        public SituacaoAluno Situacao { get; private set; }
        public Guid ResponsavelId { get; }

        //E.F Relation
        public Responsavel Responsavel { get; }

        // For EF
        protected Aluno() { }

        public Aluno(string nome, long cpf, DateTime dataNascimento, Guid responsavelId) : base(nome, cpf, dataNascimento)
        {
            ResponsavelId = responsavelId;
        }

        public override bool EhValido()
        {
            var validationResult = new AlunoValidation().Validate(this);
            return validationResult.IsValid;
        }

        public void TornarAtivo() => Situacao = SituacaoAluno.Ativo;

        public void TornarInativo() => Situacao = SituacaoAluno.Inativo;

        public void TornarMatriculado()
        {
            Situacao = SituacaoAluno.Matriculado;
            Matricula = Guid.NewGuid();
        }
    }
}