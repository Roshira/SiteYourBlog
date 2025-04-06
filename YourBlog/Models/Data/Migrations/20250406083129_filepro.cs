using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourBlog.Migrations
{
    /// <inheritdoc />
    public partial class filepro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteNews_AspNetUsers_UserId",
                table: "UserFavoriteNews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavoriteNews",
                table: "UserFavoriteNews");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserFavoriteNews",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "UserFavoriteNews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavoriteNews",
                table: "UserFavoriteNews",
                columns: new[] { "UserName", "NewsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteNews_AspNetUsers_UserName",
                table: "UserFavoriteNews",
                column: "UserName",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavoriteNews_AspNetUsers_UserName",
                table: "UserFavoriteNews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavoriteNews",
                table: "UserFavoriteNews");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "UserFavoriteNews");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserFavoriteNews",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavoriteNews",
                table: "UserFavoriteNews",
                columns: new[] { "UserId", "NewsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavoriteNews_AspNetUsers_UserId",
                table: "UserFavoriteNews",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
