using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using PSI.TI.GestaoEscolar.Domain.Models;

namespace PSI.TI.GestaoEscolar.Data.Mappings
{
    public class ProfessorMapping : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(p => p.Cpf)
                .IsRequired()
                .HasColumnType("bigint");

            builder.Property(p => p.DataNascimento)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(p => p.Formacao)
                .HasConversion(
                    p => JsonConvert.SerializeObject(p),
                    p => JsonConvert.DeserializeObject<List<string>>(p));

            builder.ToTable("Professores");
        }
    }
}