using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaAPI.Migrations
{
    public partial class cambiados_los_idProdPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductoPedidoId",
                table: "ProductoPedidos");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductoPedidos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductoPedidos");

            migrationBuilder.AddColumn<int>(
                name: "ProductoPedidoId",
                table: "ProductoPedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
