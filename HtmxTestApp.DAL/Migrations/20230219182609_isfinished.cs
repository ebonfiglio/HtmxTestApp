using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HtmxTestApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class isfinished : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "Games");
        }
    }
}
