using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseManagementApp.Migrations
{
    public partial class IsPaidPItoSIC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "ProductionItems");

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "StockIssueConfirmations",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "StockIssueConfirmations");

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "ProductionItems",
                type: "bit",
                nullable: true);
        }
    }
}
