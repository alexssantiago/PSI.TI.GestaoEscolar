using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSI.TI.GestaoEscolar.Domain.Models;

namespace PSI.TI.GestaoEscolar.Data.Mappings
{
    public class ResponsavelMapping : IEntityTypeConfiguration<Responsavel>
    {
        public void Configure(EntityTypeBuilder<Responsavel> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(a => a.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(a => a.Cpf)
                .IsRequired()
                .HasColumnType("bigint");

            builder.Property(a => a.DataNascimento)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(r => r.GrauParentesco)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(r => r.Ocupacao)
                .HasColumnType("varchar(200)");

            builder.Property(r => r.Renda)
                .IsRequired()
                .HasColumnType("decimal");

            builder.Property(r => r.NomeContato)
                .HasColumnType("varchar(250)");

            builder.Property(r => r.TelefoneContato)
                .IsRequired()
                .HasColumnType("int");

            // 1 : N => Responsavel : Dependentes
            builder.HasMany(r => r.Dependentes)
                .WithOne(o => o.Responsavel)
                .HasForeignKey(o => o.ResponsavelId);

            builder.ToTable("Responsaveis");
        }
    }
}