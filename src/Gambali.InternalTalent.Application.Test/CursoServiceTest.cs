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
    [Trait("Category", "Cursos")]
    public class CursoServiceTest
    {
        private CursoService _cursoService;

        private Mock<ICursoRepository> _cursoRepositoryMock;
        private readonly IMapper _mapper;


        public CursoServiceTest()
        {
            var mockMapper = new MapperConfiguration(cfg => { cfg.AddProfile(new AutomapperConfig()); });
            _mapper = mockMapper.CreateMapper();
        }

        [Fact]
        public void InsertAsync_WhenCursoDTO_IsValid_ReturnResultOk()
        {
            var cursoRepositoryMock = new Mock<ICursoRepository>();
            cursoRepositoryMock.Setup(x => x.InsertAsync(It.IsAny<Curso>())).Returns(Task.FromResult(new Curso() { Id = 1 }));

            _cursoService = new CursoService(cursoRepositoryMock.Object, _mapper);

            var cursoDto = new CursoDTO() { Nome = "Curso de Java", NumeroVagas = 20, Ativo = true };

            var resultado = _cursoService.InsertAsync(cursoDto).Result;

            Assert.True(resultado.ResponseOk);
        }

        [Fact]
        public void InsertAsync_WhenCursoDTO_IsNotValid_ReturnResponseFalse()
        {
            var cursoRepositoryMock = new Mock<ICursoRepository>();
            cursoRepositoryMock.Setup(x => x.InsertAsync(It.IsAny<Curso>())).Returns(Task.FromResult(new Curso() { Id = 1 }));

            _cursoService = new CursoService(cursoRepositoryMock.Object, _mapper);

            var cursoDto = new CursoDTO() { NumeroVagas = 20 };

            var resultado = _cursoService.InsertAsync(cursoDto).Result;

            Assert.False(resultado.ResponseOk);
        }

        [Fact]
        public void InsertAsync_WhenCursoDTO_Exception_ReturnException()
        {
            var cursoRepositoryMock = new Mock<ICursoRepository>();
            cursoRepositoryMock.Setup(x => x.InsertAsync(It.IsAny<Curso>())).Throws<Exception>();

            _cursoService = new CursoService(cursoRepositoryMock.Object, _mapper);

            var cursoDto = new CursoDTO() { NumeroVagas = 20 };

            var resultado = _cursoService.InsertAsync(cursoDto).Result;

            Assert.False(resultado.ResponseOk, resultado.Message);
        }

        [Fact]
        public void UpdateAsync_WhenCursoDTO_IsValid_ReturnCourse()
        {
            var cursoRepositoryMock = new Mock<ICursoRepository>();
            cursoRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<Curso>())).Returns(Task.FromResult(new Curso() { Id = 1, Nome = "Curso de Java 1", NumeroVagas = 20, Ativo = true }));

            _cursoService = new CursoService(cursoRepositoryMock.Object, _mapper);

            var cursoDto = new CursoDTO() { Id = 1, NumeroVagas = 20, Ativo = true };

            var resultado =  _cursoService.UpdateAsync(cursoDto).Result;

            Assert.False(resultado.ResponseOk);
        }

        [Fact]
        public void UpdateAsync_WhenCursoDTO_NotFound_ReturnNotFound()
        {
            var cursoRepositoryMock = new Mock<ICursoRepository>();
            cursoRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<Curso>())).Returns(Task.FromResult<Curso>(null));

            _cursoService = new CursoService(cursoRepositoryMock.Object, _mapper);

            var cursoDto = new CursoDTO() { Id = 1, Nome = "Curso de Java 1", NumeroVagas = 20, Ativo = true };

            var resultado = _cursoService.UpdateAsync(cursoDto).Result;

            Assert.False(resultado.ResponseOk);
        }

        [Fact]
        public void DeleteAsync_WhenCursoDTO_DeleteOk()
        {
            var cursoRepositoryMock = new Mock<ICursoRepository>();
            cursoRepositoryMock.Setup(x => x.GetOneAsync(1)).Returns(Task.FromResult(new Curso() { Id = 1, Nome = "Curso de Java", NumeroVagas = 20, Ativo = true }));

            _cursoService = new CursoService(cursoRepositoryMock.Object, _mapper);

            var resultado = _cursoService.DeleteAsync(1).Result;

            Assert.True(resultado.ResponseOk);
        }

        [Fact]
        public void DeleteAsync_WhenCursoDTO_NotFound()
        {
            var cursoRepositoryMock = new Mock<ICursoRepository>();
            cursoRepositoryMock.Setup(x => x.GetOneAsync(1)).Returns(Task.FromResult<Curso>(null));

            _cursoService = new CursoService(cursoRepositoryMock.Object, _mapper);

            var resultado = _cursoService.DeleteAsync(1).Result;

            Assert.False(resultado.ResponseOk);
        }
    }
}
