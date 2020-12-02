using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSI.TI.GestaoEscolar.Domain.Models;

namespace PSI.TI.GestaoEscolar.Data.Mappings
{
    public class DisciplinaMapping : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(EntityTypeBuilder<Disciplina> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(d => d.Descricao)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(d => d.CargaHoraria)
                .IsRequired()
                .HasColumnType("int");

            builder.HasOne(d => d.Turma)
                .WithMany(o => o.DisciplinasOfertadas)
                .HasForeignKey(o => o.TurmaId);

            builder.ToTable("Disciplinas");
        }
    }
}