using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class migrations9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_artistas_projetos_ProjetoId",
                table: "artistas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_projetos",
                table: "projetos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_artistas",
                table: "artistas");

            migrationBuilder.RenameTable(
                name: "projetos",
                newName: "Projetos");

            migrationBuilder.RenameTable(
                name: "artistas",
                newName: "Artistas");

            migrationBuilder.RenameIndex(
                name: "IX_artistas_ProjetoId",
                table: "Artistas",
                newName: "IX_Artistas_ProjetoId");

            migrationBuilder.AddColumn<string>(
                name: "ProdutoId",
                table: "Artistas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projetos",
                table: "Projetos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artistas",
                table: "Artistas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Contato",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkInstagram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkWhatsapp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkYoutube = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lixeira = table.Column<bool>(type: "bit", nullable: false),
                    Arquivado = table.Column<bool>(type: "bit", nullable: false),
                    DataDeCadastro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataDeAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Lixeira = table.Column<bool>(type: "bit", nullable: false),
                    Arquivado = table.Column<bool>(type: "bit", nullable: false),
                    DataDeCadastro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataDeAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sobre",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lixeira = table.Column<bool>(type: "bit", nullable: false),
                    Arquivado = table.Column<bool>(type: "bit", nullable: false),
                    DataDeCadastro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataDeAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sobre", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artistas_ProdutoId",
                table: "Artistas",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artistas_Produtos_ProdutoId",
                table: "Artistas",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Artistas_Projetos_ProjetoId",
                table: "Artistas",
                column: "ProjetoId",
                principalTable: "Projetos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artistas_Produtos_ProdutoId",
                table: "Artistas");

            migrationBuilder.DropForeignKey(
                name: "FK_Artistas_Projetos_ProjetoId",
                table: "Artistas");

            migrationBuilder.DropTable(
                name: "Contato");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Sobre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projetos",
                table: "Projetos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artistas",
                table: "Artistas");

            migrationBuilder.DropIndex(
                name: "IX_Artistas_ProdutoId",
                table: "Artistas");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Artistas");

            migrationBuilder.RenameTable(
                name: "Projetos",
                newName: "projetos");

            migrationBuilder.RenameTable(
                name: "Artistas",
                newName: "artistas");

            migrationBuilder.RenameIndex(
                name: "IX_Artistas_ProjetoId",
                table: "artistas",
                newName: "IX_artistas_ProjetoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_projetos",
                table: "projetos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_artistas",
                table: "artistas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_artistas_projetos_ProjetoId",
                table: "artistas",
                column: "ProjetoId",
                principalTable: "projetos",
                principalColumn: "Id");
        }
    }
}
