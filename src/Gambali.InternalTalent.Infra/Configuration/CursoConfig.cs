using Gambali.InternalTalent.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gambali.InternalTalent.Infra.Configuration
{
    public class CursoConfig : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("Curso");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.Nome).HasColumnName("Nome").HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(p => p.Descricao).HasColumnName("Descricao").HasColumnType("varchar").HasMaxLength(255);
            builder.Property(p => p.NumeroVagas).HasColumnName("NumeroVagas").HasColumnType("int").IsRequired();
            builder.Property(p => p.Ativo).HasColumnName("Ativo").HasColumnType("bit");

            builder.HasMany(r => r.Matriculas).WithOne(r => r.Curso);
        }
    }
}
