using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityPractice.Migrations
{
    /// <inheritdoc />
    public partial class appUserUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDo_AspNetUsers_UserId",
                table: "ToDo");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ToDo",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ToDo_UserId",
                table: "ToDo",
                newName: "IX_ToDo_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDo_AspNetUsers_AppUserId",
                table: "ToDo",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDo_AspNetUsers_AppUserId",
                table: "ToDo");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "ToDo",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ToDo_AppUserId",
                table: "ToDo",
                newName: "IX_ToDo_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDo_AspNetUsers_UserId",
                table: "ToDo",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
