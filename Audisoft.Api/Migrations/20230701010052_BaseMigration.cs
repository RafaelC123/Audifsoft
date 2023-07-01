using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Audisoft.Api.Migrations
{
    /// <inheritdoc />
    public partial class BaseMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Administration");

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "Administration",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "NUMERIC(20,0)", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                schema: "Administration",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "NUMERIC(20,0)", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                schema: "Administration",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "NUMERIC(20,0)", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: false),
                    StudentId = table.Column<decimal>(type: "NUMERIC(20,0)", nullable: false),
                    TeacherId = table.Column<decimal>(type: "NUMERIC(20,0)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Administration",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "Administration",
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_StudentId",
                schema: "Administration",
                table: "Notes",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_TeacherId",
                schema: "Administration",
                table: "Notes",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes",
                schema: "Administration");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "Administration");

            migrationBuilder.DropTable(
                name: "Teachers",
                schema: "Administration");
        }
    }
}
