using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballHub.Migrations
{
    /// <inheritdoc />
    public partial class DeleteTwoColFromPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RedCards",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "YellowCards",
                table: "Players");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RedCards",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YellowCards",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
