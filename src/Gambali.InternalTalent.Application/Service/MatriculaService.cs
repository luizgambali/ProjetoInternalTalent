using AutoMapper;
using Gambali.InternalTalent.Application.DTO;
using Gambali.InternalTalent.Application.Service.Interface;
using Gambali.InternalTalent.Domain.Interfaces;
using Gambali.InternalTalent.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambali.InternalTalent.Application.Service
{
    public class MatriculaService : IMatriculaService
    {
        private readonly IMatriculaRepository _matriculaRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly ICursoRepository _cursoRepository;

        private readonly IMapper _mapper;

        public MatriculaService(IMatriculaRepository matriculaRepository, 
                                IAlunoRepository alunoRepository,
                                ICursoRepository cursoRepository,
                                IMapper mapper)
        {
            _matriculaRepository = matriculaRepository;
            _cursoRepository = cursoRepository;
            _alunoRepository = alunoRepository;

            _mapper = mapper;
        }

        public async Task<ResponseDTO> InsertAsync(MatriculaDTO entity)
        {
            try
            {
                var result = _mapper.Map<Matricula>(entity);

                if (result.Validate())
                {
                    var aluno = await _alunoRepository.GetOneAsync(entity.Aluno.Id);
                    var curso = await _cursoRepository.GetOneAsync(entity.Curso.Id);

                    if (aluno == null)
                        return new ResponseDTO(false, "Aluno não cadastrado", entity, 404);

                    if (curso == null)
                        return new ResponseDTO(false, "Curso não cadastrado", entity, 404);

                    result.Aluno = aluno;
                    result.Curso = curso;

                    var matricula = await _matriculaRepository.InsertAsync(result);

                    return new ResponseDTO(true, "Matricula inserido com sucesso!", _mapper.Map<MatriculaDTO>(matricula));
                }
                else
                {
                    return new ResponseDTO(false, "Dados inválidos!", null, 400);
                }

            }
            catch (Exception ex)
            {
                return new ResponseDTO(false, "Erro ao inserir matricula", null, 500);
            }
        }

        public async Task<ResponseDTO> UpdateAsync(MatriculaDTO entity)
        {
            try
            {
                var matricula = await _matriculaRepository.GetOneAsync(entity.Id);

                if (matricula == null)
                {
                    return new ResponseDTO(false, "Matricula não encontrada!", null, 404);
                }

                matricula.DataInscricao = entity.DataInscricao;
                matricula.DataConclusao = entity.DataConclusao;

                if (matricula.Validate())
                {
                    var result = await _matriculaRepository.UpdateAsync(matricula);
                    return new ResponseDTO(true, "Dados da matricula atualizados com sucesso!", _mapper.Map<MatriculaDTO>(matricula));
                }
                else
                {
                    return new ResponseDTO(false, "Dados inválidos!", null, 400);
                }

            }
            catch (Exception)
            {
                return new ResponseDTO(false, "Erro ao atualizar dados da matricula", null, 500);
            }
        }

        public async Task<ResponseDTO> DeleteAsync(int id)
        {
            try
            {
                var matricula = await _matriculaRepository.GetOneAsync(id);

                if (matricula == null)
                    return new ResponseDTO(false, "Matricula não encontrada", null, 404);

                await _matriculaRepository.DeleteAsync(matricula);

                return new ResponseDTO(true, "Matricula excluida com sucesso");

            }
            catch (Exception)
            {
                return new ResponseDTO(false, "Erro ao excluir matricula", null, 500);
            }
        }

        public async Task<ResponseDTO> GetAllAsync()
        {
            var matriculas = await _matriculaRepository.GetAllAsync();

            return new ResponseDTO(true, "", _mapper.Map<IEnumerable<MatriculaDTO>>(matriculas));
        }

        public async Task<ResponseDTO> GetOneAsync(int id)
        {
            var matricula = await _matriculaRepository.GetOneAsync(id);

            if (matricula == null)
                return new ResponseDTO(false, "Matricula não encontrada", null, 404);

            return new ResponseDTO(true, "", _mapper.Map<MatriculaDTO>(matricula));
        }
    }
}
