using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambali.InternalTalent.Domain.Models
{
    public class Matricula: BaseEntity
    {
        public int AlunoId { get; set; }
        public int CursoId { get; set; }
        public DateTime DataInscricao { get; set; }
        public DateTime? DataConclusao { get; set; }

        public Aluno Aluno { get; set; }
        public Curso Curso { get; set; }

        public bool Validate()
        {
            if (AlunoId <= 0 || CursoId <= 0)
                return false;

            if (DataConclusao.HasValue)
                if (DataConclusao.Value < DataInscricao)
                    return false;

            return true;
        }
    }
}
