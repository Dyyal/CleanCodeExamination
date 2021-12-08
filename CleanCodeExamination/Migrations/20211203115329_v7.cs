using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanCodeExamination.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Scores_ScoreId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_ScoreId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ScoreId",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "Player",
                table: "Scores",
                newName: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_PlayerId",
                table: "Scores",
                column: "PlayerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Players_PlayerId",
                table: "Scores",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Players_PlayerId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_PlayerId",
                table: "Scores");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Scores",
                newName: "Player");

            migrationBuilder.AddColumn<Guid>(
                name: "ScoreId",
                table: "Players",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_ScoreId",
                table: "Players",
                column: "ScoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Scores_ScoreId",
                table: "Players",
                column: "ScoreId",
                principalTable: "Scores",
                principalColumn: "Id");
        }
    }
}
