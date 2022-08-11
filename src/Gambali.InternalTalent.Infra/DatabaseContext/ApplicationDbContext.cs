using Gambali.InternalTalent.Domain.Models;
using Gambali.InternalTalent.Infra.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Gambali.InternalTalent.Infra.DatabaseContext
{
    public class ApplicationDbContext: DbContext
    {

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>(new AlunoConfig().Configure);
            modelBuilder.Entity<Curso>(new CursoConfig().Configure);
            modelBuilder.Entity<Matricula>(new MatriculaConfig().Configure);
        }
    }
}
