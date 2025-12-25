using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Books_BookDtoId",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_BookDtoId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "BookDtoId",
                table: "Authors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookDtoId",
                table: "Authors",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_BookDtoId",
                table: "Authors",
                column: "BookDtoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Books_BookDtoId",
                table: "Authors",
                column: "BookDtoId",
                principalTable: "Books",
                principalColumn: "Id");
        }
    }
}
