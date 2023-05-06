using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityDB.Migrations
{
    public partial class CreateCursosTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SomethingElse",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SomethingElse",
                table: "Users");
        }
    }
}
