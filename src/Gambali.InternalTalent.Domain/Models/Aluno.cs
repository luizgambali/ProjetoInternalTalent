using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambali.InternalTalent.Domain.Models
{
    public class Aluno: BaseEntity
    {
		public string Nome { get; set; }
		public DateTime DataNascimento { get; set; }
		public string Endereco { get; set; }
		public string Bairro { get; set; }
		public string Cidade { get; set; }
		public string Estado { get; set; }
		public string Telefone { get; set; }
		public string Email { get; set; }

		public IEnumerable<Matricula> Matriculas { get; set; }

		public Aluno() { }
		public Aluno(string nome, DateTime dataNascimento, string email)
        {
			this.Nome = nome;
			this.Email = email;
			this.DataNascimento = DataNascimento;
        }


		public bool Validate()
        {
			if (string.IsNullOrEmpty(Nome) || string.IsNullOrEmpty(Email))
				return false;

			return true;
        }
    }
}
