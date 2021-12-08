using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanCodeExamination.Migrations
{
    public partial class v8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Scores_PlayerId",
                table: "Scores");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Scores",
                newName: "ScoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_PlayerId",
                table: "Scores",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Scores_PlayerId",
                table: "Scores");

            migrationBuilder.RenameColumn(
                name: "ScoreId",
                table: "Scores",
                newName: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_PlayerId",
                table: "Scores",
                column: "PlayerId",
                unique: true);
        }
    }
}
