using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CallogApp.Data.Migrations
{
    public partial class NewRequestModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Approvals");

            migrationBuilder.DropTable(
                name: "RequestTypes");

            migrationBuilder.DropTable(
                name: "ApprovalLevels");

            migrationBuilder.DropTable(
                name: "ApprovedStatuses");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "PaymentModes");

            migrationBuilder.DropTable(
                name: "Requesters");

            migrationBuilder.DropColumn(
                name: "AssignToId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignToId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApprovalLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApprovedStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovedStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentModes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentModes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requesters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requesters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Approvals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvanceRequired = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnualBudget = table.Column<double>(type: "float", nullable: false),
                    ApprovalLevelId = table.Column<int>(type: "int", nullable: false),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovedStatusId = table.Column<int>(type: "int", nullable: false),
                    AuthorisedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beneficiary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    CurrentRequest = table.Column<double>(type: "float", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeagerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentModeId = table.Column<int>(type: "int", nullable: false),
                    PreparedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequesterId = table.Column<int>(type: "int", nullable: false),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YTD = table.Column<double>(type: "float", nullable: false),
                    YTDPercent = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approvals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Approvals_ApprovalLevels_ApprovalLevelId",
                        column: x => x.ApprovalLevelId,
                        principalTable: "ApprovalLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Approvals_ApprovedStatuses_ApprovedStatusId",
                        column: x => x.ApprovedStatusId,
                        principalTable: "ApprovedStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Approvals_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Approvals_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Approvals_PaymentModes_PaymentModeId",
                        column: x => x.PaymentModeId,
                        principalTable: "PaymentModes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Approvals_Requesters_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "Requesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_ApprovalLevelId",
                table: "Approvals",
                column: "ApprovalLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_ApprovedStatusId",
                table: "Approvals",
                column: "ApprovedStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_CurrencyId",
                table: "Approvals",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_DepartmentId",
                table: "Approvals",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_PaymentModeId",
                table: "Approvals",
                column: "PaymentModeId");

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_RequesterId",
                table: "Approvals",
                column: "RequesterId");
        }
    }
}
