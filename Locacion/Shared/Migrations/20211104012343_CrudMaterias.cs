using Microsoft.EntityFrameworkCore.Migrations;

namespace Locacion.Comunes.Migrations
{
    public partial class CrudMaterias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodMateria = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    NombreMateria = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "UQ_Materia_Codmateria",
                table: "Materias",
                column: "CodMateria",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materias");
        }
    }
}
