using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Audisoft.Api.Migrations
{
    /// <inheritdoc />
    public partial class BaseMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                schema: "Administration",
                table: "Teachers",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                schema: "Administration",
                table: "Students",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                schema: "Administration",
                table: "Notes",
                newName: "UpdatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "Administration",
                table: "Teachers",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "Administration",
                table: "Students",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "Administration",
                table: "Notes",
                newName: "UpdateAt");
        }
    }
}
