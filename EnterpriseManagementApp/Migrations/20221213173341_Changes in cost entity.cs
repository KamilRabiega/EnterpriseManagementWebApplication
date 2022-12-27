using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseManagementApp.Migrations
{
    public partial class Changesincostentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Costs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PaymentDay",
                table: "Costs",
                newName: "PaymentDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Costs",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "PaymentDate",
                table: "Costs",
                newName: "PaymentDay");
        }
    }
}
