using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HtmxTestApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class countries2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_LosingTeamId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_WinningTeamId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "WinningTeamScore",
                table: "Games",
                newName: "HomeTeamScore");

            migrationBuilder.RenameColumn(
                name: "WinningTeamId",
                table: "Games",
                newName: "HomeTeamId");

            migrationBuilder.RenameColumn(
                name: "LosingTeamScore",
                table: "Games",
                newName: "AwayTeamScore");

            migrationBuilder.RenameColumn(
                name: "LosingTeamId",
                table: "Games",
                newName: "AwayTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_WinningTeamId",
                table: "Games",
                newName: "IX_Games_HomeTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_LosingTeamId",
                table: "Games",
                newName: "IX_Games_AwayTeamId");

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "Teams",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "Players",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HtmlCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CountryId",
                table: "Teams",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_AwayTeamId",
                table: "Games",
                column: "AwayTeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_HomeTeamId",
                table: "Games",
                column: "HomeTeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Countries_CountryId",
                table: "Players",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Countries_CountryId",
                table: "Teams",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_AwayTeamId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_HomeTeamId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Countries_CountryId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Countries_CountryId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Teams_CountryId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Players_CountryId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "HomeTeamScore",
                table: "Games",
                newName: "WinningTeamScore");

            migrationBuilder.RenameColumn(
                name: "HomeTeamId",
                table: "Games",
                newName: "WinningTeamId");

            migrationBuilder.RenameColumn(
                name: "AwayTeamScore",
                table: "Games",
                newName: "LosingTeamScore");

            migrationBuilder.RenameColumn(
                name: "AwayTeamId",
                table: "Games",
                newName: "LosingTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_HomeTeamId",
                table: "Games",
                newName: "IX_Games_WinningTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_AwayTeamId",
                table: "Games",
                newName: "IX_Games_LosingTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_LosingTeamId",
                table: "Games",
                column: "LosingTeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_WinningTeamId",
                table: "Games",
                column: "WinningTeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }
    }
}
