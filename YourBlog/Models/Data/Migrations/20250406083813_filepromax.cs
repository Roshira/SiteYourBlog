using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourBlog.Migrations
{
    /// <inheritdoc />
    public partial class filepromax : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteNews_AspNetUsers_UserName",
                table: "UserFavoriteNews");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "UserFavoriteNews",
                newName: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteNews_AspNetUsers_UserID",
                table: "UserFavoriteNews",
                column: "UserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteNews_AspNetUsers_UserID",
                table: "UserFavoriteNews");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "UserFavoriteNews",
                newName: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteNews_AspNetUsers_UserName",
                table: "UserFavoriteNews",
                column: "UserName",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
