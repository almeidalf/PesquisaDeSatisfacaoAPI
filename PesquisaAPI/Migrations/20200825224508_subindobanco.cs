using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace PesquisaAPI.Migrations
{
    public partial class subindobanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pesquisa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pesquisa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Respostas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Resposta = table.Column<string>(type: "varchar(3500)", nullable: true),
                    TipoCampo = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respostas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Informacoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DataResposta = table.Column<DateTime>(nullable: false),
                    RespostasId = table.Column<int>(nullable: false),
                    PerguntasId = table.Column<int>(nullable: false),
                    Observacoes = table.Column<string>(type: "varchar(3500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Informacoes_Pesquisa_PerguntasId",
                        column: x => x.PerguntasId,
                        principalTable: "Pesquisa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Informacoes_Respostas_RespostasId",
                        column: x => x.RespostasId,
                        principalTable: "Respostas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Informacoes_PerguntasId",
                table: "Informacoes",
                column: "PerguntasId");

            migrationBuilder.CreateIndex(
                name: "IX_Informacoes_RespostasId",
                table: "Informacoes",
                column: "RespostasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Informacoes");

            migrationBuilder.DropTable(
                name: "Pesquisa");

            migrationBuilder.DropTable(
                name: "Respostas");
        }
    }
}
