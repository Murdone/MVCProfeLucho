using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMarket.Data.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TUsuarios",
                newName: "Rut");

            migrationBuilder.RenameColumn(
                name: "NID",
                table: "TUsuarios",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "TUsuarios",
                newName: "Apellido");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rut",
                table: "TUsuarios",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "TUsuarios",
                newName: "NID");

            migrationBuilder.RenameColumn(
                name: "Apellido",
                table: "TUsuarios",
                newName: "LastName");
        }
    }
}
