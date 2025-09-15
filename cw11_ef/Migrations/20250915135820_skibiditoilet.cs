using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cw11_ef.Migrations
{
    /// <inheritdoc />
    public partial class skibiditoilet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EditorId",
                table: "Books",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "EditorId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "EditorId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "EditorId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Books_EditorId",
                table: "Books",
                column: "EditorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Editors_EditorId",
                table: "Books",
                column: "EditorId",
                principalTable: "Editors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Editors_EditorId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_EditorId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "EditorId",
                table: "Books");
        }
    }
}
