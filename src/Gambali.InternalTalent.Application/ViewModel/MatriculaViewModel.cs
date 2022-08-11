using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambali.InternalTalent.Application.ViewModel
{
    public class MatriculaViewModel
    {
        public int Id { get; set; }
        public AlunoViewModel Aluno { get; set; }
        public CursoViewModel Curso { get; set; }
        public DateTime DataInscricao { get; set; }
        public DateTime? DataConclusao { get; set; }
    }
}
