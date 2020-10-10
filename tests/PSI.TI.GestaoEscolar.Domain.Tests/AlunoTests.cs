using PSI.TI.GestaoEscolar.Domain.Models;
using PSI.TI.GestaoEscolar.Domain.Models.Enums;
using PSI.TI.GestaoEscolar.Domain.Models.Validations;
using PSI.TI.GestaoEscolar.Domain.Tests.Fixtures;
using System;
using Xunit;

namespace PSI.TI.GestaoEscolar.Domain.Tests
{
    [Collection(nameof(AlunoCollection))]
    public class AlunoTests
    {
        private readonly AlunoTestsFixture _alunoTestsFixture;

        public AlunoTests(AlunoTestsFixture alunoTestsFixture)
        {
            _alunoTestsFixture = alunoTestsFixture;
        }

        [Fact(DisplayName = "Novo Aluno Válido")]
        [Trait("Categoria", "Aluno")]
        public void Aluno_NovoAluno_DeveEstarValido()
        {
            // Arrange
            var aluno = _alunoTestsFixture.GerarAlunoValido();

            // Act
            var result = aluno.EhValido();

            // Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Novo Aluno Inválido")]
        [Trait("Categoria", "Aluno")]
        public void Aluno_NovoAluno_DeveEstarInvalido()
        {
            // Arrange
            var aluno = _alunoTestsFixture.GerarAlunoInvalido();

            // Act
            var result = aluno.EhValido();

            // Assert
            Assert.False(result);
        }

        [Fact(DisplayName = "Tornar Inativo Aluno Válido")]
        [Trait("Categoria", "Aluno")]
        public void TornarInativo_AlunoValido_DeveInativarAluno()
        {
            // Arrange
            var responsavelId = Guid.NewGuid();
            var aluno = new Aluno("Alexsander Santiago", 83902139072, new DateTime(1998, 03, 09), responsavelId);

            // Act 
            aluno.TornarInativo();

            // Assert
            Assert.Equal(SituacaoAluno.Inativo, aluno.Situacao);
        }

        [Fact(DisplayName = "Tornar Ativo Aluno Válido")]
        [Trait("Categoria", "Aluno")]
        public void TornarAtivo_AlunoValido_DeveAtivarAluno()
        {
            // Arrange
            var responsavelId = Guid.NewGuid();
            var aluno = new Aluno("Rafaela Pinheiro", 00075915006, new DateTime(1971, 09, 12), responsavelId);

            // Act
            aluno.TornarAtivo();

            Assert.Equal(SituacaoAluno.Ativo, aluno.Situacao);
        }

        [Fact(DisplayName = "Tornar Matriculado Aluno Válido Não Matriculado")]
        [Trait("Categoria", "Aluno")]
        public void TornarMatriculado_AlunoValidoNaoMatriculado_DeveGerarMatriculaAluno()
        {
            // Arrange
            var responsavelId = Guid.NewGuid();
            var aluno = new Aluno("Fernanda Alvarenga", 83902139072, new DateTime(1998, 03, 09), responsavelId);
            aluno.TornarAtivo();
            var situacaoInicial = aluno.Situacao;
            var matricula = aluno.Matricula;

            // Act
            aluno.TornarMatriculado();

            // Assert
            Assert.Equal(SituacaoAluno.Ativo, situacaoInicial);
            Assert.Equal(SituacaoAluno.Matriculado, aluno.Situacao);
            Assert.Equal(Guid.Empty, matricula);
            Assert.NotEqual(Guid.Empty, aluno.Matricula);
        }
    }
}