using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cube.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceDescription",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "EmployeeBirthDate",
                table: "Employees");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeEmail",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeLandline",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeePhoneNumber",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmployeeEmail",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeLandline",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeePhoneNumber",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "ServiceDescription",
                table: "Services",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Locations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EmployeeBirthDate",
                table: "Employees",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
