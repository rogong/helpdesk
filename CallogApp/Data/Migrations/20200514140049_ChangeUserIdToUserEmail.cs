using Microsoft.EntityFrameworkCore.Migrations;

namespace CallogApp.Data.Migrations
{
    public partial class ChangeUserIdToUserEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_AspNetUsers_ApplicationUserId",
                table: "Approvals");

            migrationBuilder.DropIndex(
                name: "IX_Approvals_ApplicationUserId",
                table: "Approvals");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Approvals");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Approvals");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Approvals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Approvals");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Approvals",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Approvals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_ApplicationUserId",
                table: "Approvals",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_AspNetUsers_ApplicationUserId",
                table: "Approvals",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
