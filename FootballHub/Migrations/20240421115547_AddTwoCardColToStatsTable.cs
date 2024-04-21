using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballHub.Migrations
{
    /// <inheritdoc />
    public partial class AddTwoCardColToStatsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RedCard",
                table: "Stats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YellowCard",
                table: "Stats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RedCard",
                table: "Stats");

            migrationBuilder.DropColumn(
                name: "YellowCard",
                table: "Stats");
        }
    }
}
