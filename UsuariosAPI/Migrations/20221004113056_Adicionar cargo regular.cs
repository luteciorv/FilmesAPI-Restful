using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosAPI.Migrations
{
    public partial class Adicionarcargoregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "07535aab-3800-4b82-9657-a63cb9a716b8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99997, "1d77ea6d-ca48-4b62-b115-9fd8607412b1", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "518228d5-9b1e-4cfd-8372-033cc441a3d8", "AQAAAAEAACcQAAAAEORIAcU0PLyGeX+QbtMaNHy+8x/24FsNkW4djXQskIeojy0AyTZnwJ8NZcRtd9VZxA==", "dd679619-b6bb-4fdd-b405-bbad1087652e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "37250047-053a-4104-9067-4144c7738141");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96e972c0-797b-4bda-b6e8-5c53a78ac684", "AQAAAAEAACcQAAAAEKP4sHqFfSQ0mPdCNNhivt2M5ZLErxlrFB1VnDdd4MNRlDprD8FBf5pE3eSRNgHEFA==", "59f68be3-bda5-45a3-8193-7ab2c96443fb" });
        }
    }
}
