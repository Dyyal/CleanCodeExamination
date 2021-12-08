﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanCodeExamination.Migrations
{
    public partial class v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Players_PlayerId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_PlayerId",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "Highscore",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Scores");

            migrationBuilder.AddColumn<string>(
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
                principalColumn: "ScoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Highscore",
                table: "Scores",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PlayerId",
                table: "Scores",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scores_PlayerId",
                table: "Scores",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Players_PlayerId",
                table: "Scores",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}
