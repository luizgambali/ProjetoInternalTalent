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
    [Trait("Category", "Alunos")]
    public class AlunoServiceTests
    {
        private AlunoService alunoService;
        
        private readonly IMapper _mapper;

        
        public AlunoServiceTests() 
        {
            var mockMapper = new MapperConfiguration(cfg => { cfg.AddProfile(new AutomapperConfig()); });
            _mapper = mockMapper.CreateMapper();
        }

        [Fact]
        public void InsertAsync_WhenAlunoDTO_IsValid_ReturnValidResponse()
        {
            var _alunoRepositoryMock = new Mock<IAlunoRepository>();
            _alunoRepositoryMock.Setup(x => x.InsertAsync(It.IsAny<Aluno>())).Returns(Task.FromResult(new Aluno()));

            alunoService = new AlunoService(_alunoRepositoryMock.Object, _mapper);

            var alunoDTO = new AlunoDTO() { Nome = "Aluno 1", Email = "aluno1@email.com"};

            var resultado = alunoService.InsertAsync(alunoDTO).Result;

            Assert.True(resultado.ResponseOk);
        }

        [Fact]
        public void InsertAsync_WhenAlunoDTO_IsNotValid_ReturnInvalidResponse()
        {
            var _alunoRepositoryMock = new Mock<IAlunoRepository>();
            _alunoRepositoryMock.Setup(x => x.InsertAsync(It.IsAny<Aluno>())).Returns(Task.FromResult(new Aluno()));
            
            alunoService = new AlunoService(_alunoRepositoryMock.Object, _mapper);

            var alunoDTO = new AlunoDTO() { DataNascimento = new DateTime(2005,01,01) };

            var resultado = alunoService.InsertAsync(alunoDTO).Result;

            Assert.False(resultado.ResponseOk, resultado.Message);
        }

        [Fact]
        public void InsertAsync_WhenAlunoDTO_ThrowException_ReturnException()
        {
            var _alunoRepositoryMock = new Mock<IAlunoRepository>();
            _alunoRepositoryMock.Setup(x => x.InsertAsync(It.IsAny<Aluno>())).Throws<Exception>();

            alunoService = new AlunoService(_alunoRepositoryMock.Object, _mapper);

            var alunoDTO = new AlunoDTO() { Nome = "Luiz", Email = "luiz@gmail.com" };

            var resultado = alunoService.InsertAsync(alunoDTO).Result;

            Assert.False(resultado.ResponseOk, resultado.Message);
        }

        [Fact]
        public void UpdateAsync_WhenAlunoDTO_IsValid_ReturnOk()
        {
            var _alunoRepositoryMock = new Mock<IAlunoRepository>();
            _alunoRepositoryMock.Setup(x => x.GetOneAsync(1)).Returns(Task.FromResult(new Aluno() { Id = 1, Nome = "Luiz", Email = "luiz@gmail.com" }));
            _alunoRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<Aluno>())).Returns(Task.FromResult(new Aluno() { Id = 10, Nome = "Luiz", Email = "luiz@gmail.com"}));

            alunoService = new AlunoService(_alunoRepositoryMock.Object, _mapper);

            var alunoDTO = new AlunoDTO() { Id = 1, Nome = "Luiz 123", Email = "luiz123@gmail.com" };

            var resultado = (AlunoDTO) alunoService.UpdateAsync(alunoDTO).Result.ResultObject;

            Assert.Equal("Luiz 123",  resultado.Nome);
        }

        [Fact]
        public void UpdateAsync_WhenAlunoDTO_NotFound_ReturnNotFound()
        {
            var _alunoRepositoryMock = new Mock<IAlunoRepository>();
            _alunoRepositoryMock.Setup(x => x.GetOneAsync(1)).Returns(Task.FromResult<Aluno>(null));

            alunoService = new AlunoService(_alunoRepositoryMock.Object, _mapper);

            var alunoDTO = new AlunoDTO() { Id = 1, Nome = "Luiz 123", Email = "luiz123@gmail.com" };

            var resultado = alunoService.UpdateAsync(alunoDTO).Result;

            Assert.False(resultado.ResponseOk, resultado.Message);
        }

        [Fact]
        public void DeleteAsync_WhenAlunoDTO_ReturnOk()
        {
            var _alunoRepositoryMock = new Mock<IAlunoRepository>();
            _alunoRepositoryMock.Setup(x => x.GetOneAsync(1)).Returns(Task.FromResult(new Aluno() { Id = 1, Nome = "Luiz", Email = "luiz@gmail.com" }));

            alunoService = new AlunoService(_alunoRepositoryMock.Object, _mapper);

            var resultado = alunoService.DeleteAsync(1).Result;

            Assert.True(resultado.ResponseOk);
        }

        [Fact]
        public void DeleteAsync_WhenAlunoDTO_NotFound()
        {
            var _alunoRepositoryMock = new Mock<IAlunoRepository>();
            _alunoRepositoryMock.Setup(x => x.GetOneAsync(1)).Returns(Task.FromResult<Aluno>(null));

            alunoService = new AlunoService(_alunoRepositoryMock.Object, _mapper);

            var resultado = alunoService.DeleteAsync(1).Result;

            Assert.False(resultado.ResponseOk);
        }
    }
}
