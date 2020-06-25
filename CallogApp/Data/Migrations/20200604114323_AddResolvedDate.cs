using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CallogApp.Data.Migrations
{
    public partial class AddResolvedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_OwnerDepartments_OwnerDepartmentId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_OwnerDepartmentId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "OwnerDepartmentId",
                table: "Requests");

            migrationBuilder.AddColumn<DateTime>(
                name: "ResolvedDate",
                table: "Requests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResolvedDate",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "OwnerDepartmentId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_OwnerDepartmentId",
                table: "Requests",
                column: "OwnerDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_OwnerDepartments_OwnerDepartmentId",
                table: "Requests",
                column: "OwnerDepartmentId",
                principalTable: "OwnerDepartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
