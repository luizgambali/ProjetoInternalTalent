using AutoMapper;
using Gambali.InternalTalent.Application.ViewModel;
using Gambali.InternalTalent.Domain.Models;

namespace Gambali.InternalTalent.Application.Mapper
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Aluno, AlunoViewModel>().ReverseMap();
            CreateMap<Curso, CursoViewModel>().ReverseMap();
            CreateMap<Matricula, MatriculaViewModel>().ReverseMap();
        }
    }
}
