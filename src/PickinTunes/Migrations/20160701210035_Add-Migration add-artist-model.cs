using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PickinTunes.Migrations
{
    public partial class AddMigrationaddartistmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ArtistId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtistName = table.Column<string>(nullable: true),
                    TuneId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ArtistId);
                    table.ForeignKey(
                        name: "FK_Artist_Tune_TuneId",
                        column: x => x.TuneId,
                        principalTable: "Tune",
                        principalColumn: "TuneId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AlterColumn<string>(
                name: "TuneTitle",
                table: "Tune",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artist_TuneId",
                table: "Artist",
                column: "TuneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.AlterColumn<int>(
                name: "TuneTitle",
                table: "Tune",
                nullable: false);
        }
    }
}
