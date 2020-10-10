using PSI.TI.GestaoEscolar.Domain.DomainObjects;
using PSI.TI.GestaoEscolar.Domain.Models;
using PSI.TI.GestaoEscolar.Domain.Models.Enums;
using System;
using Xunit;

namespace PSI.TI.GestaoEscolar.Domain.Tests
{
    public class ResponsavelTests
    {
        [Fact(DisplayName = "Adicionar Novo Aluno Dependente")]
        [Trait("Categoria", "Responsavel")]
        public void AdicionarDependente_NovoAlunoDependente_DeveTornarAlunoAtivo()
        {
            // Arrange
            var responsavel = new Responsavel("Caio Ribeiro", 64205600046, new DateTime(1979, 09, 11),
                "Pai", "Arquiteto de Software", 22000, "Maria Clara", 31999991213);

            var aluno = new Aluno("Isabela Galhardo", 18391359050, new DateTime(2000, 12, 12), responsavel.Id);

            // Act
            responsavel.AdicionarDependente(aluno);

            // Assert
            Assert.Equal(SituacaoAluno.Ativo, aluno.Situacao);
        }

        [Fact(DisplayName = "Adicionar Aluno Dependente Existente")]
        [Trait("Categoria", "Responsavel")]
        public void AdicionarDependente_AlunoDependenteExistente_DeveRetornarException()
        {
            // Arrange
            var responsavel = new Responsavel("Caio Ribeiro", 64205600046, new DateTime(1979, 09, 11),
                "Pai", "Arquiteto de Software", 22000, "Maria Clara", 31999991213);
            var aluno = new Aluno("Isabela Galhardo", 18391359050, new DateTime(2000, 12, 12), responsavel.Id);
            var aluno2 = new Aluno("Isabela Galhardo", 18391359050, new DateTime(2002, 11, 12), responsavel.Id);
            responsavel.AdicionarDependente(aluno);

            // Act & Assert
            Assert.Throws<DomainException>(() => responsavel.AdicionarDependente(aluno2));
        }

        [Fact(DisplayName = "Adicionar Aluno Dependente associado a outro Responsável")]
        [Trait("Categoria", "Responsavel")]
        public void AdicionarDependente_AlunoAssociadoAOutroResponsavel_DeveRetornarException()
        {
            // Arrange
            var responsavel = new Responsavel("Caio Ribeiro", 64205600046, new DateTime(1979, 09, 11),
                "Pai", "Arquiteto de Software", 22000, "Maria Clara", 31999991213);
            var responsavelId = Guid.NewGuid();
            var aluno = new Aluno("Isabela Galhardo", 18391359050, new DateTime(2000, 12, 12), responsavelId);

            // Act & Assert
            Assert.Throws<DomainException>(() => responsavel.AdicionarDependente(aluno));
        }
    }
}