using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class migration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistaProjeto");

            migrationBuilder.AddColumn<string>(
                name: "ProjetoId",
                table: "artistas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_artistas_ProjetoId",
                table: "artistas",
                column: "ProjetoId");

            migrationBuilder.AddForeignKey(
                name: "FK_artistas_projetos_ProjetoId",
                table: "artistas",
                column: "ProjetoId",
                principalTable: "projetos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_artistas_projetos_ProjetoId",
                table: "artistas");

            migrationBuilder.DropIndex(
                name: "IX_artistas_ProjetoId",
                table: "artistas");

            migrationBuilder.DropColumn(
                name: "ProjetoId",
                table: "artistas");

            migrationBuilder.CreateTable(
                name: "ArtistaProjeto",
                columns: table => new
                {
                    ArtistasId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjetosId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistaProjeto", x => new { x.ArtistasId, x.ProjetosId });
                    table.ForeignKey(
                        name: "FK_ArtistaProjeto_artistas_ArtistasId",
                        column: x => x.ArtistasId,
                        principalTable: "artistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistaProjeto_projetos_ProjetosId",
                        column: x => x.ProjetosId,
                        principalTable: "projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistaProjeto_ProjetosId",
                table: "ArtistaProjeto",
                column: "ProjetosId");
        }
    }
}
