using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseManagementApp.Migrations
{
    public partial class ShortValuehall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortValue",
                table: "Halls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortValue",
                table: "Halls");
        }
    }
}
