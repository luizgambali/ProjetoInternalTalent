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
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IMapper _mapper;

        public CursoService(ICursoRepository cursoRepository, IMapper mapper)
        {
            _cursoRepository = cursoRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDTO> InsertAsync(CursoDTO entity)
        {
            try
            {
                var result = _mapper.Map<Curso>(entity);

                if (result.Validate())
                {
                    var curso = await _cursoRepository.InsertAsync(result);
                    return new ResponseDTO(true, "Curso inserido com sucesso!", _mapper.Map<CursoDTO>(curso));
                }
                else
                {
                    return new ResponseDTO(false, "Dados inválidos!", null, 400);
                }

            }
            catch (Exception)
            {
                return new ResponseDTO(false, "Erro ao inserir curso", null, 500);
            }
        }

        public async Task<ResponseDTO> UpdateAsync(CursoDTO entity)
        {
            try
            {
                var curso = await _cursoRepository.GetOneAsync(entity.Id);

                if (curso == null)
                {
                    return new ResponseDTO(false, "Curso não encontrado!", null, 404);
                }

                curso.Nome = entity.Nome;
                curso.Descricao = entity.Descricao;
                curso.NumeroVagas = entity.NumeroVagas;
                curso.Ativo = true;

                if (curso.Validate())
                {
                    var result = await _cursoRepository.UpdateAsync(curso);
                    return new ResponseDTO(true, "Dados do curso atualizados com sucesso!", _mapper.Map<CursoDTO>(curso));
                }
                else
                {
                    return new ResponseDTO(false, "Dados inválidos!", null, 400);
                }

            }
            catch (Exception)
            {
                return new ResponseDTO(false, "Erro ao atualizar dados do curso", null, 500);
            }
        }

        public async Task<ResponseDTO> DeleteAsync(int id)
        {
            try
            {
                var curso = await _cursoRepository.GetOneAsync(id);

                if (curso == null)
                    return new ResponseDTO(false, "Curso não encontrado", null, 404);

                await _cursoRepository.DeleteAsync(curso);

                return new ResponseDTO(true, "Curso excluido com sucesso");

            }
            catch (Exception)
            {
                return new ResponseDTO(false, "Erro ao excluir curso", null, 500);
            }
        }

        public async Task<ResponseDTO> GetAllAsync()
        {
            var cursos = await _cursoRepository.GetAllAsync();

            return new ResponseDTO(true, "", _mapper.Map<IEnumerable<CursoDTO>>(cursos));
        }

        public async Task<ResponseDTO> GetOneAsync(int id)
        {
            var curso = await _cursoRepository.GetOneAsync(id);

            if (curso == null)
                return new ResponseDTO(false, "Curso não encontrado", null, 404);

            return new ResponseDTO(true, "", _mapper.Map<CursoDTO>(curso));
        }
    }
}
