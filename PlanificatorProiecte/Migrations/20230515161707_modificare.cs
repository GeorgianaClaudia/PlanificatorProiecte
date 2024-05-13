using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanificatorProiecte.Migrations
{
    /// <inheritdoc />
    public partial class modificare : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Termen",
                table: "Alocari",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Termen",
                table: "Alocari");
        }
    }
}
