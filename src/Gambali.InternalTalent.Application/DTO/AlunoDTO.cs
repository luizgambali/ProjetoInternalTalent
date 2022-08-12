using System;
using System.ComponentModel.DataAnnotations;

namespace Gambali.InternalTalent.Application.ViewModel
{
    public class AlunoDto
    {
		public int Id { get; set; }

		[Required]
		public string Nome { get; set; }
		[Required]
		public DateTime DataNascimento { get; set; }
		public string Endereco { get; set; }
		public string Bairro { get; set; }
		public string Cidade { get; set; }
		public string Estado { get; set; }
		public string Telefone { get; set; }

		[Required]
		public string Email { get; set; }
	}
}
