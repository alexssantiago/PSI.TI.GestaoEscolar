using PSI.TI.GestaoEscolar.Domain.Models.Validations;
using System;

namespace PSI.TI.GestaoEscolar.Domain.Models
{
    public class Disciplina : Entity
    {
        public string Descricao { get; private set; }
        public int CargaHoraria { get; private set; }
        public Guid? TurmaId { get; private set; }

        // EF Relation
        public Turma Turma { get; }

        // For EF
        protected Disciplina()
        {
        }

        public Disciplina(string descricao, int cargaHoraria)
        {
            Descricao = descricao;
            CargaHoraria = cargaHoraria;
        }

        public Disciplina(string descricao, int cargaHoraria, Guid turmaId)
        {
            Descricao = descricao;
            CargaHoraria = cargaHoraria;
            TurmaId = turmaId;
        }

        public override bool EhValido() => new DisciplinaValidation().Validate(this).IsValid;
    }
}