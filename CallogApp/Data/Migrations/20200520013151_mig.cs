using Microsoft.EntityFrameworkCore.Migrations;

namespace CallogApp.Data.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_ApprovalLevels_ApprovalLevelId",
                table: "Approvals");

            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_ApprovedStatuses_ApprovedStatusId",
                table: "Approvals");

            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_Currencies_CurrencyId",
                table: "Approvals");

            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_Departments_DepartmentId",
                table: "Approvals");

            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_PaymentModes_PaymentModeId",
                table: "Approvals");

            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_Requesters_RequesterId",
                table: "Approvals");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Departments_DepartmentId",
                table: "Calls");

            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Issues_IssueId",
                table: "Calls");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Departments_DepartmentId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Devices_DeviceId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_ITStaffs_ITStaffId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Issues_IssueId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_RequestTypes_RequestTypeId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Statuses_StatusId",
                table: "Requests");

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_ApprovalLevels_ApprovalLevelId",
                table: "Approvals",
                column: "ApprovalLevelId",
                principalTable: "ApprovalLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_ApprovedStatuses_ApprovedStatusId",
                table: "Approvals",
                column: "ApprovedStatusId",
                principalTable: "ApprovedStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_Currencies_CurrencyId",
                table: "Approvals",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_Departments_DepartmentId",
                table: "Approvals",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_PaymentModes_PaymentModeId",
                table: "Approvals",
                column: "PaymentModeId",
                principalTable: "PaymentModes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_Requesters_RequesterId",
                table: "Approvals",
                column: "RequesterId",
                principalTable: "Requesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Departments_DepartmentId",
                table: "Calls",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Issues_IssueId",
                table: "Calls",
                column: "IssueId",
                principalTable: "Issues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Departments_DepartmentId",
                table: "Requests",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Devices_DeviceId",
                table: "Requests",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_ITStaffs_ITStaffId",
                table: "Requests",
                column: "ITStaffId",
                principalTable: "ITStaffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Issues_IssueId",
                table: "Requests",
                column: "IssueId",
                principalTable: "Issues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_RequestTypes_RequestTypeId",
                table: "Requests",
                column: "RequestTypeId",
                principalTable: "RequestTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Statuses_StatusId",
                table: "Requests",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_ApprovalLevels_ApprovalLevelId",
                table: "Approvals");

            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_ApprovedStatuses_ApprovedStatusId",
                table: "Approvals");

            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_Currencies_CurrencyId",
                table: "Approvals");

            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_Departments_DepartmentId",
                table: "Approvals");

            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_PaymentModes_PaymentModeId",
                table: "Approvals");

            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_Requesters_RequesterId",
                table: "Approvals");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Departments_DepartmentId",
                table: "Calls");

            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Issues_IssueId",
                table: "Calls");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Departments_DepartmentId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Devices_DeviceId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_ITStaffs_ITStaffId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Issues_IssueId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_RequestTypes_RequestTypeId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Statuses_StatusId",
                table: "Requests");

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_ApprovalLevels_ApprovalLevelId",
                table: "Approvals",
                column: "ApprovalLevelId",
                principalTable: "ApprovalLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_ApprovedStatuses_ApprovedStatusId",
                table: "Approvals",
                column: "ApprovedStatusId",
                principalTable: "ApprovedStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_Currencies_CurrencyId",
                table: "Approvals",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_Departments_DepartmentId",
                table: "Approvals",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_PaymentModes_PaymentModeId",
                table: "Approvals",
                column: "PaymentModeId",
                principalTable: "PaymentModes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_Requesters_RequesterId",
                table: "Approvals",
                column: "RequesterId",
                principalTable: "Requesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Departments_DepartmentId",
                table: "Calls",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Issues_IssueId",
                table: "Calls",
                column: "IssueId",
                principalTable: "Issues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Departments_DepartmentId",
                table: "Requests",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Devices_DeviceId",
                table: "Requests",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_ITStaffs_ITStaffId",
                table: "Requests",
                column: "ITStaffId",
                principalTable: "ITStaffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Issues_IssueId",
                table: "Requests",
                column: "IssueId",
                principalTable: "Issues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_RequestTypes_RequestTypeId",
                table: "Requests",
                column: "RequestTypeId",
                principalTable: "RequestTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Statuses_StatusId",
                table: "Requests",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
