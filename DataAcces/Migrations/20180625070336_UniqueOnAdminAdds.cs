using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataAcces.Migrations
{
    public partial class UniqueOnAdminAdds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Localities_Name",
                table: "Localities");

            migrationBuilder.CreateIndex(
                name: "IX_Localities_Name",
                table: "Localities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interests_Name",
                table: "Interests",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Localities_Name",
                table: "Localities");

            migrationBuilder.DropIndex(
                name: "IX_Interests_Name",
                table: "Interests");

            migrationBuilder.CreateIndex(
                name: "IX_Localities_Name",
                table: "Localities",
                column: "Name");
        }
    }
}
