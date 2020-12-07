using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaAPI.Migrations
{
    public partial class changed_Identity_ProductosPedidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
