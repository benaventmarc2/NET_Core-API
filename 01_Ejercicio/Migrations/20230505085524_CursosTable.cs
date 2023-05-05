using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _01_Ejercicio.Migrations
{
    public partial class CursosTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescripcionCorta = table.Column<string>(type: "nvarchar(280)", maxLength: 280, nullable: true),
                    DescripcionLarga = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicoObjetivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Objetivos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Requisitos = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Nombre);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Curso");
        }
    }
}
