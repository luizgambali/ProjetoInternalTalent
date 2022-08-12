using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambali.InternalTalent.Application.DTO
{
    public class RegistroDTO
    {
        [Required]
        public int AlunoId { get; set; }
        [Required]
        public int CursoId { get; set; }
        [Required]
        public DateTime DataRegistro { get; set; }
    }
}
