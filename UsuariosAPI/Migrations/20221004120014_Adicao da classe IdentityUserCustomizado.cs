using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosAPI.Migrations
{
    public partial class AdicaodaclasseIdentityUserCustomizado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "5879e1d4-ed3d-4b35-b87a-91cc2bcd23d4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "891e989d-ed55-4934-9e03-5442049c08ee");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9615af18-e5ac-4939-85f4-d97ab2ee0632", "AQAAAAEAACcQAAAAEJw3NF4erSdd2H07HcC4i+AWVgJ0sFoiFMY4a4e5+rdkSlfuL89ImEee1mDEQKFpAg==", "aae75a71-c3d0-4986-82e7-d132a1677e9f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "1d77ea6d-ca48-4b62-b115-9fd8607412b1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "07535aab-3800-4b82-9657-a63cb9a716b8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "518228d5-9b1e-4cfd-8372-033cc441a3d8", "AQAAAAEAACcQAAAAEORIAcU0PLyGeX+QbtMaNHy+8x/24FsNkW4djXQskIeojy0AyTZnwJ8NZcRtd9VZxA==", "dd679619-b6bb-4fdd-b405-bbad1087652e" });
        }
    }
}
