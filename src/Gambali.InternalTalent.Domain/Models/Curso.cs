using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambali.InternalTalent.Domain.Models
{
    public class Curso: BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int NumeroVagas { get; set; }
        public bool Ativo { get; set; }

        public IEnumerable<Matricula> Matriculas { get; set; }

        public Curso()
        {
            Ativo = true;
        }

        public Curso(string nome, string descricao, int numeroVagas)
        {
            this.Nome = nome;
            this.Descricao = descricao;
            this.NumeroVagas = numeroVagas;
            this.Ativo = true;
        }

        public bool Validate()
        {
            if (string.IsNullOrEmpty(Nome) || NumeroVagas <= 0)
                return false;

            return true;
        }

    }
}
