using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemplateAPI.SQL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPrimeiraAvaliacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResponsavelNF = table.Column<bool>(type: "bit", nullable: false),
                    RG = table.Column<string>(type: "varchar(100)", nullable: true),
                    CPF = table.Column<string>(type: "varchar(100)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Responsavel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Profissao = table.Column<string>(type: "varchar(100)", nullable: true),
                    ResponsavelNF = table.Column<bool>(type: "bit", nullable: false),
                    ResponsavelPrincipal = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(100)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RG = table.Column<string>(type: "varchar(100)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsavel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "varchar(100)", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: true),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: true),
                    Estado = table.Column<string>(type: "varchar(100)", nullable: true),
                    CEP = table.Column<string>(type: "varchar(100)", nullable: true),
                    IdPaciente = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Paciente_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PacienteResponsavel",
                columns: table => new
                {
                    PacientesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsaveisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteResponsavel", x => new { x.PacientesId, x.ResponsaveisId });
                    table.ForeignKey(
                        name: "FK_PacienteResponsavel_Paciente_PacientesId",
                        column: x => x.PacientesId,
                        principalTable: "Paciente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PacienteResponsavel_Responsavel_ResponsaveisId",
                        column: x => x.ResponsaveisId,
                        principalTable: "Responsavel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_IdPaciente",
                table: "Endereco",
                column: "IdPaciente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PacienteResponsavel_ResponsaveisId",
                table: "PacienteResponsavel",
                column: "ResponsaveisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "PacienteResponsavel");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Responsavel");
        }
    }
}
