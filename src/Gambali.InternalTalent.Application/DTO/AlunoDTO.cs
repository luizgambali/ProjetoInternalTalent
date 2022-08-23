using System;
using System.ComponentModel.DataAnnotations;

namespace Gambali.InternalTalent.Application.DTO
{
    public class AlunoDTO
    {
		public int Id { get; set; }
		public string Nome { get; set; }
		public DateTime DataNascimento { get; set; }
		public string Endereco { get; set; }
		public string Bairro { get; set; }
		public string Cidade { get; set; }
		public string Estado { get; set; }
		public string Telefone { get; set; }
		public string Email { get; set; }
	}
}
