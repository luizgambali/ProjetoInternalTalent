using Gambali.InternalTalent.Domain.Interfaces;
using Gambali.InternalTalent.Domain.Models;
using Gambali.InternalTalent.Infra.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Gambali.InternalTalent.Infra.Repository
{
    public class MatriculaRepository: BaseRepository<Matricula>, IMatriculaRepository
    {
        public MatriculaRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

        public async Task<bool> CancelarMatriculasAluno(int alunoId)
        {
            var matriculas = await _dbSet.Where(p => p.AlunoId == alunoId).ToListAsync();

            if (matriculas != null && matriculas.Count > 0)
            {
                foreach(var matricula in matriculas)
                {
                    matricula.DataConclusao = DateTime.Now;
                    await UpdateAsync(matricula);
                }
            }

            return true;
        }

        public async Task<bool> CancelarMatriculasCurso(int cursoId)
        {
            var matriculas = await _dbSet.Where(p => p.CursoId == cursoId).ToListAsync();

            if (matriculas != null && matriculas.Count > 0)
            {
                foreach (var matricula in matriculas)
                {
                    matricula.DataConclusao = DateTime.Now;
                    await UpdateAsync(matricula);
                }
            }

            return true;
        }
    }
}
