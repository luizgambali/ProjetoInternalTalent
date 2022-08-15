using AutoMapper;
using Gambali.InternalTalent.Application.DTO;
using Gambali.InternalTalent.Application.Service.Interface;
using Gambali.InternalTalent.Domain.Interfaces;
using Gambali.InternalTalent.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gambali.InternalTalent.Application.Service
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public AlunoService(IAlunoRepository alunoRepository, IMapper mapper)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDTO> InsertAsync(AlunoDTO entity)
        {
            try
            {
                var result = _mapper.Map<Aluno>(entity);

                if (result.Validate())
                {
                    var aluno = await _alunoRepository.InsertAsync(result);
                    return new ResponseDTO(true, "Aluno inserido com sucesso!", _mapper.Map<AlunoDTO>(aluno));
                }
                else
                {
                    return new ResponseDTO(false, "Dados inválidos!", null, 400);
                }

            }
            catch(Exception ex)
            {
                return new ResponseDTO(false, "Erro ao inserir aluno", null, 500);
            }
        }

        public async Task<ResponseDTO> UpdateAsync(AlunoDTO entity)
        {
            try
            {
                var aluno = await _alunoRepository.GetOneAsync(entity.Id);

                if (aluno == null)
                {
                    return new ResponseDTO(false, "Aluno não encontrado!", null, 404);
                }

                aluno.Nome = entity.Nome;
                aluno.DataNascimento = entity.DataNascimento;
                aluno.Endereco = entity.Endereco;
                aluno.Bairro = entity.Bairro;
                aluno.Cidade = entity.Cidade;
                aluno.Estado = entity.Estado;
                aluno.Telefone = entity.Telefone;
                aluno.Email = entity.Email;

                if (aluno.Validate())
                {
                    var result = await _alunoRepository.UpdateAsync(aluno);
                    return new ResponseDTO(true, "Dados do aluno atualizados com sucesso!", _mapper.Map<AlunoDTO>(aluno));
                }
                else
                {
                    return new ResponseDTO(false, "Dados inválidos!", null, 400);
                }

            }
            catch(Exception)
            {
                return new ResponseDTO(false, "Erro ao atualizar dados do aluno", null, 500);
            }
        }

        public async Task<ResponseDTO> DeleteAsync(int id)
        {
            try
            {
                var aluno = await _alunoRepository.GetOneAsync(id);

                if (aluno == null)
                    return new ResponseDTO(false, "Aluno não encontrado", null, 404);

                await _alunoRepository.DeleteAsync(aluno);

                return new ResponseDTO(true, "Aluno excluido com sucesso");

            }
            catch(Exception)
            {
                return new ResponseDTO(false, "Erro ao excluir aluno", null, 500);
            }
        }

        public async Task<ResponseDTO> GetAllAsync()
        {
            var alunos = await _alunoRepository.GetAllAsync();

            if (alunos == null || alunos.Count() == 0)
                return new ResponseDTO(false, "Nenhum aluno cadastrado", null, 404);
            else
                return new ResponseDTO(true, "", _mapper.Map<IEnumerable<Aluno>>(alunos));
        }

        public async Task<ResponseDTO> GetOneAsync(int id)
        {
            var aluno = await _alunoRepository.GetOneAsync(id);

            if (aluno == null)
                return new ResponseDTO(false, "Aluno não encontrado", null, 404);
            else
                return new ResponseDTO(true, "", _mapper.Map<Aluno>(aluno));
        }


    }
}
