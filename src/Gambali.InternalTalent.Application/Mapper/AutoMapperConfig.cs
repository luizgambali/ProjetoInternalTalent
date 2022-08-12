using AutoMapper;
using Gambali.InternalTalent.Application.ViewModel;
using Gambali.InternalTalent.Domain.Models;

namespace Gambali.InternalTalent.Application.Mapper
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Aluno, AlunoDto>().ReverseMap();
            CreateMap<Curso, CursoDTO>().ReverseMap();
            CreateMap<Matricula, MatriculaDTO>().ReverseMap();
        }
    }
}
