using Gambali.InternalTalent.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gambali.InternalTalent.Infra.Configuration
{
    public class MatriculaConfig : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            builder.ToTable("Matricula");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.AlunoId).HasColumnName("AlunoId").IsRequired();
            builder.Property(p => p.CursoId).HasColumnName("CursoId").IsRequired();
            builder.Property(p => p.DataInscricao).HasColumnName("DataInscricao").HasColumnType("datetime2").IsRequired();
            builder.Property(p => p.DataConclusao).HasColumnName("DataConclusao").HasColumnType("datetime2");

            builder.HasOne(r => r.Aluno).WithMany(r => r.Matriculas);
            builder.HasOne(r => r.Curso).WithMany(r => r.Matriculas);

        }
    }
}
