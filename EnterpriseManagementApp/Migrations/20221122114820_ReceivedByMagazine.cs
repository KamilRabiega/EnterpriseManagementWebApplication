using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseManagementApp.Migrations
{
    public partial class ReceivedByMagazine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ReceivedByMagazine",
                table: "ProductionItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceivedByMagazine",
                table: "ProductionItems");
        }
    }
}
