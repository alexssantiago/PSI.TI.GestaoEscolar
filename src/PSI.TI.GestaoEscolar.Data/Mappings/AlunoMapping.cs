using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSI.TI.GestaoEscolar.Domain.Models;

namespace PSI.TI.GestaoEscolar.Data.Mappings
{
    public class AlunoMapping : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(a => a.Cpf)
                .IsRequired()
                .HasColumnType("bigint");

            builder.Property(a => a.DataNascimento)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(a => a.Matricula)
                .HasColumnType("uniqueidentifier");

            builder.Property(a => a.Situacao)
                .IsRequired()
                .HasColumnType("int");

            builder.ToTable("Alunos");
        }
    }
}