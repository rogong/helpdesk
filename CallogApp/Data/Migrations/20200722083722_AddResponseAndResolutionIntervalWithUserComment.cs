using Microsoft.EntityFrameworkCore.Migrations;

namespace CallogApp.Data.Migrations
{
    public partial class AddResponseAndResolutionIntervalWithUserComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResolutionInterval",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponseInterval",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserComment",
                table: "Requests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResolutionInterval",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ResponseInterval",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "UserComment",
                table: "Requests");
        }
    }
}
