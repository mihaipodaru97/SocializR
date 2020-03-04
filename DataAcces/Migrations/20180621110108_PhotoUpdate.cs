using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataAcces.Migrations
{
    public partial class PhotoUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Post",
                table: "Photos");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Posts_PostId",
                table: "Photos",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Posts_PostId",
                table: "Photos");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Post",
                table: "Photos",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
