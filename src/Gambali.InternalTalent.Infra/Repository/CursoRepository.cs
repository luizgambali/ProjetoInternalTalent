using Gambali.InternalTalent.Domain.Interfaces;
using Gambali.InternalTalent.Domain.Models;
using Gambali.InternalTalent.Infra.DatabaseContext;

namespace Gambali.InternalTalent.Infra.Repository
{
    public class CursoRepository: BaseRepository<Curso>, ICursoRepository
    {
        public CursoRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
    }
}
