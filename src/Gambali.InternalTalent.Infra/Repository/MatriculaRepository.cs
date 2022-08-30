using Gambali.InternalTalent.Domain.Interfaces;
using Gambali.InternalTalent.Domain.Models;
using Gambali.InternalTalent.Infra.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gambali.InternalTalent.Infra.Repository
{
    public class MatriculaRepository: BaseRepository<Matricula>, IMatriculaRepository
    {
        public MatriculaRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }


        public override async Task<Matricula> GetOneAsync(int id)
        {
            return await _dbSet.Include(i => i.Aluno).Include(i => i.Curso).FirstOrDefaultAsync(p => p.Id == id);
        }
        public override async Task<IEnumerable<Matricula>> GetAllAsync()
        {
            return await _dbSet.Include(i => i.Aluno).Include(i => i.Curso).ToListAsync();
        }

    }
}
