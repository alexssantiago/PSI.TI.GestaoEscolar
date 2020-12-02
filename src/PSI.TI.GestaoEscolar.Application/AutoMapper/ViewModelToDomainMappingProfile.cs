using AutoMapper;
using PSI.TI.GestaoEscolar.Application.ViewModels;
using PSI.TI.GestaoEscolar.Domain.Models;

namespace PSI.TI.GestaoEscolar.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ResponsavelViewModel, Responsavel>()
                .ConstructUsing(r =>
                    new Responsavel(r.Nome, r.Cpf, r.DataNascimento, r.GrauParentesco, r.Ocupacao, r.Renda,
                        r.NomeContato, r.TelefoneContato));

            CreateMap<AlunoViewModel, Aluno>()
                .ConstructUsing(a => new Aluno(a.Nome, a.Cpf, a.DataNascimento, a.ResponsavelId));

            CreateMap<ProfessorViewModel, Professor>()
                .ConstructUsing(p => new Professor(p.Nome, p.Cpf, p.DataNascimento, p.Formacao));

            CreateMap<DisciplinaViewModel, Disciplina>()
                .ConstructUsing(d => new Disciplina(d.Descricao, d.CargaHoraria));

            CreateMap<MatriculaViewModel, Matricula>()
                .ConstructUsing(m => new Matricula(m.AlunoId, m.TurmaId));
        }
    }
}