using System;
using PSI.TI.GestaoEscolar.Business.Models.Enums;

namespace PSI.TI.GestaoEscolar.Business.Models
{
    public class Aluno : Pessoa
    {
        public Guid Matricula { get; private set; }
        public SituacaoAluno Situacao { get; private set; }
        public Guid ResponsavelId { get; private set; }

        //E.F Relation
        public Responsavel Responsavel { get; private set; }

        // For EF
        protected Aluno()
        {

        }

        public Aluno(string nome, string cpf, DateTime dataNascimento, Guid matricula, Guid responsavelId) : base(nome, cpf, dataNascimento)
        {
            Matricula = matricula;
            ResponsavelId = responsavelId;
            TornarAtivo();
        }

        public void TornarAtivo() => Situacao = SituacaoAluno.Ativo;
    }
}