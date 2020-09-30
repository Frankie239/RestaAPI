using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaAPI.Migrations
{
    public partial class ArregloEstado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "estado",
                table: "Pedidos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estado",
                table: "Pedidos");
        }
    }
}
