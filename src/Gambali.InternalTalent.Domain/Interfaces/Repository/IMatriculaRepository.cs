using Gambali.InternalTalent.Domain.Models;
using System.Threading.Tasks;

namespace Gambali.InternalTalent.Domain.Interfaces
{
    public interface IMatriculaRepository: IBaseRepository<Matricula>
    {
        Task<bool> CancelarMatriculasCurso(int cursoId);
        Task<bool> CancelarMatriculasAluno(int alunoId);
    }
}
