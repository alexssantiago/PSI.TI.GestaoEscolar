﻿using AutoMapper;
using PSI.TI.GestaoEscolar.Application.ViewModels;
using PSI.TI.GestaoEscolar.Domain.Models;

namespace PSI.TI.GestaoEscolar.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Responsavel, ResponsavelViewModel>();
            CreateMap<Aluno, AlunoViewModel>();
            CreateMap<Disciplina, DisciplinaViewModel>();
            CreateMap<Professor, ProfessorViewModel>();
            CreateMap<Turma, TurmaViewModel>();
            CreateMap<Matricula, MatriculaViewModel>();
        }
    }
}