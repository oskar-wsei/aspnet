using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BooksAppData.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    author = table.Column<string>(type: "TEXT", nullable: false),
                    pages = table.Column<int>(type: "INTEGER", nullable: false),
                    isbn = table.Column<string>(type: "TEXT", nullable: true),
                    publish_year = table.Column<int>(type: "INTEGER", nullable: true),
                    publisher = table.Column<string>(type: "TEXT", nullable: true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "id", "author", "created_at", "isbn", "pages", "publish_year", "publisher", "title", "updated_at" },
                values: new object[,]
                {
                    { 1, "Andrew Lock", new DateTime(2021, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 370, 2017, null, "ASP.NET Core in Action", null },
                    { 2, "Christian Gammelgaard", new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 300, 2020, null, "Microservices in .NET", null },
                    { 3, "Marinko Spasojevic", new DateTime(2018, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 250, 2019, null, "Ultimate ASP.NET Core Web API", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");
        }
    }
}
