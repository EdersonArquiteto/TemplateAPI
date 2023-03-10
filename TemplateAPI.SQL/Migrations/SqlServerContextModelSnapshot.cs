// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TemplateAPI.SQL.Contexts;

#nullable disable

namespace TemplateAPI.SQL.Migrations
{
    [DbContext(typeof(SqlServerContext))]
    partial class SqlServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PacienteResponsavel", b =>
                {
                    b.Property<Guid>("PacientesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ResponsaveisId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PacientesId", "ResponsaveisId");

                    b.HasIndex("ResponsaveisId");

                    b.ToTable("PacienteResponsavel");
                });

            modelBuilder.Entity("TemplateAPI.Domain.Entities.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bairro")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CEP")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cidade")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Estado")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("IdPaciente")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Logradouro")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdPaciente")
                        .IsUnique();

                    b.ToTable("Endereco", (string)null);
                });

            modelBuilder.Entity("TemplateAPI.Domain.Entities.Paciente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPrimeiraAvaliacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("RG")
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("ResponsavelNF")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("TemplateAPI.Domain.Entities.Responsavel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Profissao")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("RG")
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("ResponsavelNF")
                        .HasColumnType("bit");

                    b.Property<bool>("ResponsavelPrincipal")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Responsavel");
                });

            modelBuilder.Entity("PacienteResponsavel", b =>
                {
                    b.HasOne("TemplateAPI.Domain.Entities.Paciente", null)
                        .WithMany()
                        .HasForeignKey("PacientesId")
                        .IsRequired();

                    b.HasOne("TemplateAPI.Domain.Entities.Responsavel", null)
                        .WithMany()
                        .HasForeignKey("ResponsaveisId")
                        .IsRequired();
                });

            modelBuilder.Entity("TemplateAPI.Domain.Entities.Endereco", b =>
                {
                    b.HasOne("TemplateAPI.Domain.Entities.Paciente", "Paciente")
                        .WithOne("Endereco")
                        .HasForeignKey("TemplateAPI.Domain.Entities.Endereco", "IdPaciente")
                        .IsRequired();

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("TemplateAPI.Domain.Entities.Paciente", b =>
                {
                    b.OwnsOne("TemplateAPI.Domain.VO.CPF", "CPF", b1 =>
                        {
                            b1.Property<Guid>("PacienteId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("varchar(100)")
                                .HasColumnName("CPF");

                            b1.HasKey("PacienteId");

                            b1.ToTable("Paciente");

                            b1.WithOwner()
                                .HasForeignKey("PacienteId");
                        });

                    b.Navigation("CPF")
                        .IsRequired();
                });

            modelBuilder.Entity("TemplateAPI.Domain.Entities.Responsavel", b =>
                {
                    b.OwnsOne("TemplateAPI.Domain.VO.CPF", "CPF", b1 =>
                        {
                            b1.Property<Guid>("ResponsavelId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("CPF");

                            b1.HasKey("ResponsavelId");

                            b1.ToTable("Responsavel");

                            b1.WithOwner()
                                .HasForeignKey("ResponsavelId");
                        });

                    b.OwnsOne("TemplateAPI.Domain.VO.Telefone", "Celular", b1 =>
                        {
                            b1.Property<Guid>("ResponsavelId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Celular");

                            b1.HasKey("ResponsavelId");

                            b1.ToTable("Responsavel");

                            b1.WithOwner()
                                .HasForeignKey("ResponsavelId");
                        });

                    b.OwnsOne("TemplateAPI.Domain.VO.Telefone", "Telefone", b1 =>
                        {
                            b1.Property<Guid>("ResponsavelId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Telefone");

                            b1.HasKey("ResponsavelId");

                            b1.ToTable("Responsavel");

                            b1.WithOwner()
                                .HasForeignKey("ResponsavelId");
                        });

                    b.OwnsOne("TemplateAPI.Domain.VO.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("ResponsavelId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Email");

                            b1.HasKey("ResponsavelId");

                            b1.ToTable("Responsavel");

                            b1.WithOwner()
                                .HasForeignKey("ResponsavelId");
                        });

                    b.Navigation("CPF")
                        .IsRequired();

                    b.Navigation("Celular")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Telefone")
                        .IsRequired();
                });

            modelBuilder.Entity("TemplateAPI.Domain.Entities.Paciente", b =>
                {
                    b.Navigation("Endereco");
                });
#pragma warning restore 612, 618
        }
    }
}
