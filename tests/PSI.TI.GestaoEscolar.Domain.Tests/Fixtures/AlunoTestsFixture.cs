using Bogus;
using Bogus.DataSets;
using PSI.TI.GestaoEscolar.Domain.Models;
using System;
using Bogus.Extensions.Brazil;
using Xunit;

namespace PSI.TI.GestaoEscolar.Domain.Tests.Fixtures
{
    [CollectionDefinition(nameof(AlunoCollection))]
    public class AlunoCollection : ICollectionFixture<AlunoTestsFixture> { }

    public class AlunoTestsFixture : IDisposable
    {
        public Aluno GerarAlunoValido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var aluno = new Faker<Aluno>("pt_BR")
                .CustomInstantiator(f => new Aluno(
                    f.Name.FullName(genero),
                    Int64.Parse(f.Person.Cpf(false)),
                    f.Date.Past(80, DateTime.Now.AddYears(-18)),
                    Guid.NewGuid()));

            return aluno;
        }

        public Aluno GerarAlunoInvalido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var aluno = new Faker<Aluno>("pt_BR")
                .CustomInstantiator(a => new Aluno(
                    a.Name.FullName(genero),
                    Int64.Parse(a.Person.Cpf(false)),
                    a.Date.Past(80, DateTime.Now.AddYears(-18)),
                    Guid.Empty));

            return aluno;
        }

        public void Dispose()
        {
        }
    }
}