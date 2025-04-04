using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourBlog.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNewsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessLevel",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                table: "News",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MetaKeywords",
                table: "News",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "News",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessLevel",
                table: "News");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                table: "News");

            migrationBuilder.DropColumn(
                name: "MetaKeywords",
                table: "News");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "News");
        }
    }
}
