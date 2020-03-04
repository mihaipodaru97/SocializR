using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DataAcces.Migrations
{
    public partial class Datetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Posts",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Comments",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Posts",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Comments",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }
    }
}
