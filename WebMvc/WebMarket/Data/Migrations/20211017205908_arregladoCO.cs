using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMarket.Data.Migrations
{
    public partial class arregladoCO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Direction",
                table: "TClientes",
                newName: "Direccion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Direccion",
                table: "TClientes",
                newName: "Direction");
        }
    }
}
