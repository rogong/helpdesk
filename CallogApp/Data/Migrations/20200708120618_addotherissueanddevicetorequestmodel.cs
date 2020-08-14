using Microsoft.EntityFrameworkCore.Migrations;

namespace CallogApp.Data.Migrations
{
    public partial class addotherissueanddevicetorequestmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OtherDevice",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherIssue",
                table: "Requests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OtherDevice",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "OtherIssue",
                table: "Requests");
        }
    }
}
