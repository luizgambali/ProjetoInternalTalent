using Gambali.InternalTalent.Domain.Interfaces;
using Gambali.InternalTalent.Domain.Models;
using Gambali.InternalTalent.Infra.DatabaseContext;

namespace Gambali.InternalTalent.Infra.Repository
{
    public class AlunoRepository: BaseRepository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
    }
}
