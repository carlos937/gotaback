using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class migration8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Arquivado",
                table: "projetos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeAtualizacao",
                table: "projetos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeCadastro",
                table: "projetos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Lixeira",
                table: "projetos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Arquivado",
                table: "artistas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeAtualizacao",
                table: "artistas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataDeCadastro",
                table: "artistas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Lixeira",
                table: "artistas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Arquivado",
                table: "projetos");

            migrationBuilder.DropColumn(
                name: "DataDeAtualizacao",
                table: "projetos");

            migrationBuilder.DropColumn(
                name: "DataDeCadastro",
                table: "projetos");

            migrationBuilder.DropColumn(
                name: "Lixeira",
                table: "projetos");

            migrationBuilder.DropColumn(
                name: "Arquivado",
                table: "artistas");

            migrationBuilder.DropColumn(
                name: "DataDeAtualizacao",
                table: "artistas");

            migrationBuilder.DropColumn(
                name: "DataDeCadastro",
                table: "artistas");

            migrationBuilder.DropColumn(
                name: "Lixeira",
                table: "artistas");
        }
    }
}
