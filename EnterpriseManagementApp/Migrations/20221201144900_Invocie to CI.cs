using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseManagementApp.Migrations
{
    public partial class InvocietoCI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.CreateTable(
                name: "StockIssueConfirmations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CIName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CINumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    EmaCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Net = table.Column<int>(type: "int", nullable: false),
                    Gross = table.Column<int>(type: "int", nullable: false),
                    TaxClassId = table.Column<int>(type: "int", nullable: true),
                    ProductionItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfPayment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CIDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockIssueConfirmations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockIssueConfirmations_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockIssueConfirmations_ProductionItems_ProductionItemId",
                        column: x => x.ProductionItemId,
                        principalTable: "ProductionItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockIssueConfirmations_Taxes_TaxClassId",
                        column: x => x.TaxClassId,
                        principalTable: "Taxes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockIssueConfirmations_CompanyId",
                table: "StockIssueConfirmations",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_StockIssueConfirmations_ProductionItemId",
                table: "StockIssueConfirmations",
                column: "ProductionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StockIssueConfirmations_TaxClassId",
                table: "StockIssueConfirmations",
                column: "TaxClassId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockIssueConfirmations");

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    ProductionItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxClassId = table.Column<int>(type: "int", nullable: true),
                    DateOfPayment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmaCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gross = table.Column<int>(type: "int", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Net = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_ProductionItems_ProductionItemId",
                        column: x => x.ProductionItemId,
                        principalTable: "ProductionItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Taxes_TaxClassId",
                        column: x => x.TaxClassId,
                        principalTable: "Taxes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CompanyId",
                table: "Invoices",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ProductionItemId",
                table: "Invoices",
                column: "ProductionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_TaxClassId",
                table: "Invoices",
                column: "TaxClassId");
        }
    }
}
