using System.ComponentModel.DataAnnotations;

namespace Gambali.InternalTalent.Application.DTO
{
    public class CursoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int NumeroVagas { get; set; }
        public bool Ativo { get; set; }
    }
}
