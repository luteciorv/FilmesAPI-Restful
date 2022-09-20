using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmesAPI.Migrations
{
    public partial class TabeladeGerenteseRelaçãoentreGerenteseCinemas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GerenteID",
                table: "Cinemas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Gerentes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerentes", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_GerenteID",
                table: "Cinemas",
                column: "GerenteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Gerentes_GerenteID",
                table: "Cinemas",
                column: "GerenteID",
                principalTable: "Gerentes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Gerentes_GerenteID",
                table: "Cinemas");

            migrationBuilder.DropTable(
                name: "Gerentes");

            migrationBuilder.DropIndex(
                name: "IX_Cinemas_GerenteID",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "GerenteID",
                table: "Cinemas");
        }
    }
}
