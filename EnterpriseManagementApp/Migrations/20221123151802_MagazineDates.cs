using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseManagementApp.Migrations
{
    public partial class MagazineDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MagPickupDate",
                table: "ProductionItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "ProductionItems",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MagPickupDate",
                table: "ProductionItems");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "ProductionItems");
        }
    }
}
