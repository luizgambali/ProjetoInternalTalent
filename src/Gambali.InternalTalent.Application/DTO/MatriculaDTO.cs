using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambali.InternalTalent.Application.DTO
{
    public class MatriculaDTO
    {
        public int Id { get; set; }
        public AlunoDTO Aluno { get; set; }
        public CursoDTO Curso { get; set; }
        public DateTime DataInscricao { get; set; }
        public DateTime? DataConclusao { get; set; }
    }
}
