using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CallogApp.Data.Migrations
{
    public partial class RequestAdjustment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_RequestTypes_RequestTypeId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_RequestTypeId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestTypeId",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "AssignToId",
                table: "Requests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResponseDate",
                table: "Requests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Requests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignToId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ResponseDate",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "RequestTypeId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestTypeId",
                table: "Requests",
                column: "RequestTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_RequestTypes_RequestTypeId",
                table: "Requests",
                column: "RequestTypeId",
                principalTable: "RequestTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
