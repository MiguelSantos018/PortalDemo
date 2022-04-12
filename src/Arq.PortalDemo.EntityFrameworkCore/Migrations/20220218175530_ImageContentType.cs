using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arq.PortalDemo.Migrations
{
    public partial class ImageContentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageContentType",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageContentType",
                table: "Movies");
        }
    }
}
