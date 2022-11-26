using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseManagementApp.Migrations
{
    public partial class DeleteCompanytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductionItems_Companies_CompanyId",
                table: "ProductionItems");

            migrationBuilder.DropIndex(
                name: "IX_ProductionItems_CompanyId",
                table: "ProductionItems");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "ProductionItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "ProductionItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductionItems_CompanyId",
                table: "ProductionItems",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionItems_Companies_CompanyId",
                table: "ProductionItems",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
