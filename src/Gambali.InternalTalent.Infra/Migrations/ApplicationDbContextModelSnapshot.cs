﻿// <auto-generated />
using System;
using Gambali.InternalTalent.Infra.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gambali.InternalTalent.Infra.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("Gambali.InternalTalent.Domain.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<string>("Bairro")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("Cidade")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<string>("Endereco")
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<string>("Estado")
                        .HasMaxLength(15)
                        .HasColumnType("varchar");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<string>("Telefone")
                        .HasMaxLength(20)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Alunos", (string)null);
                });

            modelBuilder.Entity("Gambali.InternalTalent.Domain.Models.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("Ativo");

                    b.Property<string>("Descricao")
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("Descricao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Nome");

                    b.Property<int>("NumeroVagas")
                        .HasColumnType("int")
                        .HasColumnName("NumeroVagas");

                    b.HasKey("Id");

                    b.ToTable("Curso", (string)null);
                });

            modelBuilder.Entity("Gambali.InternalTalent.Domain.Models.Matricula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<int>("AlunoId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("AlunoId");

                    b.Property<int>("CursoId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("CursoId");

                    b.Property<DateTime?>("DataConclusao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataConclusao");

                    b.Property<DateTime>("DataInscricao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataInscricao");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("CursoId");

                    b.ToTable("Matricula", (string)null);
                });

            modelBuilder.Entity("Gambali.InternalTalent.Domain.Models.Matricula", b =>
                {
                    b.HasOne("Gambali.InternalTalent.Domain.Models.Aluno", "Aluno")
                        .WithMany("Matriculas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gambali.InternalTalent.Domain.Models.Curso", "Curso")
                        .WithMany("Matriculas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("Gambali.InternalTalent.Domain.Models.Aluno", b =>
                {
                    b.Navigation("Matriculas");
                });

            modelBuilder.Entity("Gambali.InternalTalent.Domain.Models.Curso", b =>
                {
                    b.Navigation("Matriculas");
                });
#pragma warning restore 612, 618
        }
    }
}
