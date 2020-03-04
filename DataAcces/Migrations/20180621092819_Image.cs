using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAcces.Migrations
{
    public partial class Image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Photos",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "image");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Photos",
                type: "image",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldNullable: true);
        }
    }
}
