using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PickinTunes.Migrations
{
    public partial class TuneArtistModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_Tune_TuneId",
                table: "Artist");

            migrationBuilder.DropIndex(
                name: "IX_Artist_TuneId",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "TuneId",
                table: "Artist");

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Tune",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tune_ArtistId",
                table: "Tune",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tune_Artist_ArtistId",
                table: "Tune",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tune_Artist_ArtistId",
                table: "Tune");

            migrationBuilder.DropIndex(
                name: "IX_Tune_ArtistId",
                table: "Tune");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Tune");

            migrationBuilder.AddColumn<int>(
                name: "TuneId",
                table: "Artist",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artist_TuneId",
                table: "Artist",
                column: "TuneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_Tune_TuneId",
                table: "Artist",
                column: "TuneId",
                principalTable: "Tune",
                principalColumn: "TuneId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
