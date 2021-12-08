using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanCodeExamination.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Scores_ScoreId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.AddColumn<double>(
                name: "Average",
                table: "Players",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Players",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Guesses",
                table: "Players",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Highscore",
                table: "Players",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoundsPlayed",
                table: "Players",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Players_ScoreId",
                table: "Players",
                column: "ScoreId",
                principalTable: "Players",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Players_ScoreId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Average",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Guesses",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Highscore",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RoundsPlayed",
                table: "Players");

            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Average = table.Column<double>(type: "REAL", nullable: false),
                    Guesses = table.Column<int>(type: "INTEGER", nullable: false),
                    Highscore = table.Column<int>(type: "INTEGER", nullable: false),
                    Player = table.Column<string>(type: "TEXT", nullable: true),
                    RoundsPlayed = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Scores_ScoreId",
                table: "Players",
                column: "ScoreId",
                principalTable: "Scores",
                principalColumn: "Id");
        }
    }
}
