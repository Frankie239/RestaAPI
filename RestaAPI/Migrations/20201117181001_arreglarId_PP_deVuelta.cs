using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaAPI.Migrations
{
    public partial class arreglarId_PP_deVuelta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductoPedidos");

            migrationBuilder.AddColumn<int>(
                name: "ProductoPedidoId",
                table: "ProductoPedidos",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductoPedidoId",
                table: "ProductoPedidos");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductoPedidos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
