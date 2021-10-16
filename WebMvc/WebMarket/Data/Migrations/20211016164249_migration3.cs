using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebMarket.Data.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TClientes",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Credit = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TClientes", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "TReports_clients",
                columns: table => new
                {
                    IdReport = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Debt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Monthly = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Change = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DatePayment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentDebt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateDebt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ticket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    TClientesIdClient = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TReports_clients", x => x.IdReport);
                    table.ForeignKey(
                        name: "FK_TReports_clients_TClientes_TClientesIdClient",
                        column: x => x.TClientesIdClient,
                        principalTable: "TClientes",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TReports_clients_TClientesIdClient",
                table: "TReports_clients",
                column: "TClientesIdClient");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TReports_clients");

            migrationBuilder.DropTable(
                name: "TClientes");
        }
    }
}
