using Microsoft.EntityFrameworkCore.Migrations;

namespace CallogApp.Data.Migrations
{
    public partial class AddEmailToITStaff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ITStaffs",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "ITStaffs");
        }
    }
}
