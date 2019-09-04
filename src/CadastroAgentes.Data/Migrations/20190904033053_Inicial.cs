using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroAgentes.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Codigo = table.Column<decimal>(type: "numeric(3)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(200)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    Altura = table.Column<decimal>(type: "numeric(3,2)", nullable: false),
                    Peso = table.Column<decimal>(type: "numeric(6,3)", nullable: false),
                    StatusId = table.Column<Guid>(nullable: true),
                    UsuarioAnalise = table.Column<Guid>(nullable: true),
                    DataTerminoAnalise = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(200)", nullable: false),
                    DataAbertura = table.Column<DateTime>(type: "datetime", nullable: false),
                    QtdFuncionarios = table.Column<decimal>(type: "numeric(10)", nullable: false),
                    StatusId = table.Column<Guid>(nullable: true),
                    UsuarioAnalise = table.Column<Guid>(nullable: true),
                    DataTerminoAnalise = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fornecedores_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Codigo", "Descricao" },
                values: new object[,]
                {
                    { new Guid("eb1642e8-698d-4c49-8e0f-dcc73cad1710"), 1m, "Cadastro Prévio" },
                    { new Guid("405a2544-7237-4741-804b-263976e2fc0a"), 2m, "Pendente" },
                    { new Guid("9b8892a7-a034-4654-bc07-82966911eaf2"), 3m, "Encaminhado" },
                    { new Guid("007a9788-2206-453d-9fc5-38b54d1231df"), 4m, "Aprovado" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_StatusId",
                table: "Clientes",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_StatusId",
                table: "Fornecedores",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
