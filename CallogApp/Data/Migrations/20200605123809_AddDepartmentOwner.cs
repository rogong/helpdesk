using Microsoft.EntityFrameworkCore.Migrations;

namespace CallogApp.Data.Migrations
{
    public partial class AddDepartmentOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OwnerDepartments");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentOwner",
                table: "Requests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentOwner",
                table: "Requests");

            migrationBuilder.CreateTable(
                name: "OwnerDepartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerDepartments", x => x.Id);
                });
        }
    }
}
