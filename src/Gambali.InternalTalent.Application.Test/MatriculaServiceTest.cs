using AutoMapper;
using Gambali.InternalTalent.Application.DTO;
using Gambali.InternalTalent.Application.Mapper;
using Gambali.InternalTalent.Application.Service;
using Gambali.InternalTalent.Domain.Interfaces;
using Gambali.InternalTalent.Domain.Models;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Gambali.InternalTalent.Application.Test
{
    [Trait("Category", "Matricula")]
    public class MatriculaServiceTest
    {
        private MatriculaService matriculaService;

        private readonly IMapper _mapper;

        public MatriculaServiceTest()
        {
            var mockMapper = new MapperConfiguration(cfg => { cfg.AddProfile(new AutomapperConfig()); });
            _mapper = mockMapper.CreateMapper();
        }

        [Fact]
        public void InsertAsync_WhenAlunoAndCursoDTO_IsValid_ReturnOk()
        {
            var matriculaRepositoryMock = new Mock<IMatriculaRepository>();
            var alunoRepositoryMock = new Mock<IAlunoRepository>();
            var cursoRepositoryMock = new Mock<ICursoRepository>();

            alunoRepositoryMock.Setup(x => x.GetOneAsync(1)).Returns(Task.FromResult(new Aluno() { Id = 1, Nome = "Luiz", Email = "luiz@gmail.com" }));
            cursoRepositoryMock.Setup(x => x.GetOneAsync(1)).Returns(Task.FromResult(new Curso() { Id = 1, Nome = "Curso de Java" }));
            matriculaRepositoryMock.Setup(x => x.InsertAsync(It.IsAny<Matricula>())).Returns(Task.FromResult(new Matricula() {  Id = 1 }));

            matriculaService = new MatriculaService(matriculaRepositoryMock.Object, 
                                                    alunoRepositoryMock.Object, 
                                                    cursoRepositoryMock.Object, 
                                                    _mapper);

            var alunoDTO = new AlunoDTO() { Id = 1 };
            var cursoDTO = new CursoDTO() { Id = 1 };

            var matriculaDTO = new MatriculaDTO() { Aluno = alunoDTO, Curso = cursoDTO, DataInscricao = DateTime.Now, DataConclusao = null };

            var resultado = matriculaService.InsertAsync(matriculaDTO).Result;

            Assert.True(resultado.ResponseOk);
        }

        [Fact]
        public void InsertAsync_WhenAlunoAndCursoDTO_IsNotValid_ReturnInValidResponse()
        {
            var matriculaRepositoryMock = new Mock<IMatriculaRepository>();
            var alunoRepositoryMock = new Mock<IAlunoRepository>();
            var cursoRepositoryMock = new Mock<ICursoRepository>();

            alunoRepositoryMock.Setup(x => x.GetOneAsync(1)).Returns(Task.FromResult<Aluno>(null));
            cursoRepositoryMock.Setup(x => x.GetOneAsync(1)).Returns(Task.FromResult(new Curso() { Id = 1, Nome = "Curso de Java" }));
            matriculaRepositoryMock.Setup(x => x.InsertAsync(It.IsAny<Matricula>())).Returns(Task.FromResult(new Matricula() { Id = 1 }));

            matriculaService = new MatriculaService(matriculaRepositoryMock.Object,
                                                    alunoRepositoryMock.Object,
                                                    cursoRepositoryMock.Object,
                                                    _mapper);

            var alunoDTO = new AlunoDTO() { Id = 1 };
            var cursoDTO = new CursoDTO() { Id = 1 };

            var matriculaDTO = new MatriculaDTO() { Aluno = alunoDTO, Curso = cursoDTO, DataInscricao = DateTime.Now, DataConclusao = null };

            var resultado = matriculaService.InsertAsync(matriculaDTO).Result;

            Assert.False(resultado.ResponseOk);
        }
    }
}
