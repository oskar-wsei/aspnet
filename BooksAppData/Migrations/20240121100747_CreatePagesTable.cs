using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BooksAppData.Migrations
{
    /// <inheritdoc />
    public partial class CreatePagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pages",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    slug = table.Column<string>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    content = table.Column<string>(type: "TEXT", nullable: true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pages", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "pages",
                columns: new[] { "id", "content", "created_at", "slug", "title", "updated_at" },
                values: new object[,]
                {
                    { 1, "<p>Welcome to my page</p>", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "home", "Home", null },
                    { 2, "<p>This is the about page</p>", new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "about", "About", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_pages_slug",
                table: "pages",
                column: "slug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pages");
        }
    }
}
