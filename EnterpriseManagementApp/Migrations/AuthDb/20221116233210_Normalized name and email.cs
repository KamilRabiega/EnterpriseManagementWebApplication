using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseManagementApp.Migrations.AuthDb
{
    public partial class Normalizednameandemail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2918c9e-cc63-4d1e-8d90-647b4ba66561",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "e54d185a-85d1-44da-bcf2-988e46041bd8", "admin@emapp.com", "ADMIN@EMAPP.COM", "ADMIN@EMAPP.COM", "AQAAAAEAACcQAAAAEKDDVTNFIu8/7Izscv9ckoiaZe2oNByMzczyriqNhfSeC62RiE/kClRCcvl5SXug2g==", "a176c1f8-adf4-4430-9b70-1db52322743b", "admin@emapp.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2918c9e-cc63-4d1e-8d90-647b4ba66561",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "79dfe350-eb90-42b3-91f6-a2a153ec7193", "user@emapp.com", null, null, "AQAAAAEAACcQAAAAEEf0B8VPXjonCuF/00/6owATnVp7iKqtkuUxlkc0i7mcpO/Ca/hBfqkClaCyrGJ0qw==", "794f7fee-f711-4746-806f-7d095e4d03b0", "user@emapp.com" });
        }
    }
}
