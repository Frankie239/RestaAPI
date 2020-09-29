using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaAPI.Migrations
{
    public partial class AgregodetallesClienteYMozo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Mozos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Salario",
                table: "Mozos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MedioDePagoPreferido",
                table: "clientes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Mozos");

            migrationBuilder.DropColumn(
                name: "Salario",
                table: "Mozos");

            migrationBuilder.DropColumn(
                name: "MedioDePagoPreferido",
                table: "clientes");
        }
    }
}
