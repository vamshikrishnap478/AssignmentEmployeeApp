using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatenewcoulmcreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Createdate",
                table: "Employee",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Createdate",
                table: "Employee");
        }
    }
}
