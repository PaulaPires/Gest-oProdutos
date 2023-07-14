using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infraestrutura.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FORNECEDOR",
                columns: table => new
                {
                    CODIGO_FORNECEDOR = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FORNECEDOR", x => x.CODIGO_FORNECEDOR);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    CODIGO_PRODUTO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRICAO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SITUACAO = table.Column<int>(type: "int", nullable: true),
                    DATA_FABRICACAO = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DATA_VALIDADE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CODIGO_FORNECEDOR = table.Column<int>(type: "int", nullable: true),
                    Propriedade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mensagem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.CODIGO_PRODUTO);
                    table.ForeignKey(
                        name: "FK_Produto_FORNECEDOR_CODIGO_FORNECEDOR",
                        column: x => x.CODIGO_FORNECEDOR,
                        principalTable: "FORNECEDOR",
                        principalColumn: "CODIGO_FORNECEDOR",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CODIGO_FORNECEDOR",
                table: "Produto",
                column: "CODIGO_FORNECEDOR");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "FORNECEDOR");
        }
    }
}
