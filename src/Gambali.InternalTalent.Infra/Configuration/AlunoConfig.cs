using Gambali.InternalTalent.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gambali.InternalTalent.Infra.Configuration
{
    public class AlunoConfig : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Alunos");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.Nome).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            builder.Property(p => p.DataNascimento).HasColumnType("datetime2").IsRequired();
            builder.Property(p => p.Endereco).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(p => p.Bairro).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(p => p.Cidade).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(p => p.Estado).HasColumnType("varchar").HasMaxLength(15);
            builder.Property(p => p.Telefone).HasColumnType("varchar").HasMaxLength(20);
            builder.Property(p => p.Email).HasColumnType("varchar").HasMaxLength(100);

            builder.HasMany(r => r.Matriculas).WithOne(r => r.Aluno);
        }
    }
}
