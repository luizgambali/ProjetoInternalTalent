using System.ComponentModel.DataAnnotations;

namespace Gambali.InternalTalent.Application.DTO
{
    public class CursoDTO
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
        public string Descricao { get; set; }

        [Required]
        public int NumeroVagas { get; set; }
        public bool Ativo { get; set; }
    }
}
