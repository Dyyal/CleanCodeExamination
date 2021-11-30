using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanCodeExamination.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guesses",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Highscore",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RoundsPlayed",
                table: "Players");

            migrationBuilder.AddColumn<Guid>(
                name: "ScoreId",
                table: "Players",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Score",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoundsPlayed = table.Column<int>(type: "INTEGER", nullable: false),
                    Guesses = table.Column<int>(type: "INTEGER", nullable: false),
                    Highscore = table.Column<int>(type: "INTEGER", nullable: false),
                    Average = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Score", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_ScoreId",
                table: "Players",
                column: "ScoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Score_ScoreId",
                table: "Players",
                column: "ScoreId",
                principalTable: "Score",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Score_ScoreId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "Score");

            migrationBuilder.DropIndex(
                name: "IX_Players_ScoreId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ScoreId",
                table: "Players");

            migrationBuilder.AddColumn<int>(
                name: "Guesses",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Highscore",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoundsPlayed",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
