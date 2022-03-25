using Microsoft.EntityFrameworkCore.Migrations;

namespace Schaken.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Speler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partij",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dag = table.Column<int>(type: "int", nullable: false),
                    Uitslag = table.Column<int>(type: "int", nullable: false),
                    SpelerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partij", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partij_Speler_SpelerId",
                        column: x => x.SpelerId,
                        principalTable: "Speler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partij_SpelerId",
                table: "Partij",
                column: "SpelerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partij");

            migrationBuilder.DropTable(
                name: "Speler");
        }
    }
}
