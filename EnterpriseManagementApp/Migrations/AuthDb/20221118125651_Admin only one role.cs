using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseManagementApp.Migrations.AuthDb
{
    public partial class Adminonlyonerole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "25130d10-ec6c-4023-bda9-e4684f35a55b", "a2918c9e-cc63-4d1e-8d90-647b4ba66561" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2725d629-db33-4423-adca-27a89f547db4", "a2918c9e-cc63-4d1e-8d90-647b4ba66561" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7c19e5f1-e8ed-49e0-bd6a-0b6aaf411cc9", "a2918c9e-cc63-4d1e-8d90-647b4ba66561" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "931f8a9e-0b6e-47e3-a77c-9bc734d99a1e", "a2918c9e-cc63-4d1e-8d90-647b4ba66561" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ab2aed5b-2505-4011-b6e3-d7aea499fbb0", "a2918c9e-cc63-4d1e-8d90-647b4ba66561" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2918c9e-cc63-4d1e-8d90-647b4ba66561",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3fcf02eb-3e95-4015-aef0-e4de04a8f5d0", "AQAAAAEAACcQAAAAEGvqIVSfc1vgGlZNrxBMKAsjw/A/lMRoBTovZdUZD2Hsw99rlqAAv43+1tX2HKWJFA==", "affd16b5-3bff-45a4-9dcf-55656e628738" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "25130d10-ec6c-4023-bda9-e4684f35a55b", "a2918c9e-cc63-4d1e-8d90-647b4ba66561" },
                    { "2725d629-db33-4423-adca-27a89f547db4", "a2918c9e-cc63-4d1e-8d90-647b4ba66561" },
                    { "7c19e5f1-e8ed-49e0-bd6a-0b6aaf411cc9", "a2918c9e-cc63-4d1e-8d90-647b4ba66561" },
                    { "931f8a9e-0b6e-47e3-a77c-9bc734d99a1e", "a2918c9e-cc63-4d1e-8d90-647b4ba66561" },
                    { "ab2aed5b-2505-4011-b6e3-d7aea499fbb0", "a2918c9e-cc63-4d1e-8d90-647b4ba66561" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2918c9e-cc63-4d1e-8d90-647b4ba66561",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e54d185a-85d1-44da-bcf2-988e46041bd8", "AQAAAAEAACcQAAAAEKDDVTNFIu8/7Izscv9ckoiaZe2oNByMzczyriqNhfSeC62RiE/kClRCcvl5SXug2g==", "a176c1f8-adf4-4430-9b70-1db52322743b" });
        }
    }
}
