using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSI.TI.GestaoEscolar.Domain.Models;

namespace PSI.TI.GestaoEscolar.Data.Mappings
{
    public class TurmaMapping : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasOne(t => t.Professor)
                .WithMany(o => o.Turmas)
                .HasForeignKey(o => o.ProfessorId);

            builder.ToTable("Turmas");
        }
    }
}