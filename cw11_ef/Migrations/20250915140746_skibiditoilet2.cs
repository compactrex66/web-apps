using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cw11_ef.Migrations
{
    /// <inheritdoc />
    public partial class skibiditoilet2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Editors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Editors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Editors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Editors",
                keyColumn: "Id",
                keyValue: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Editors",
                columns: new[] { "Id", "Adress", "Name" },
                values: new object[,]
                {
                    { 1, "ul. Wookkk, Kraków 31-161", "Appress" },
                    { 2, "ul. lik, Kraków 67-161", "Skibid" },
                    { 3, "ul. daw, Kraków 31-543", "Mustard" },
                    { 4, "ul. kil, Kraków 31-811", "Mango" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "EditorId", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 1, "Andrzej Sapkowski", 1, new DateTime(1993, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wiedźmin: Ostatnie życzenie" },
                    { 2, "J.K. Rowling", 2, new DateTime(1997, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter i Kamień Filozoficzny" },
                    { 3, "J.R.R. Tolkien", 3, new DateTime(1937, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hobbit, czyli tam i z powrotem" }
                });
        }
    }
}
