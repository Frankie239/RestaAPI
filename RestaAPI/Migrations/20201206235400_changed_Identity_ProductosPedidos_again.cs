using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaAPI.Migrations
{
    public partial class changed_Identity_ProductosPedidos_again : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductoPedidos",
                table: "ProductoPedidos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductoPedidos",
                table: "ProductoPedidos",
                column: "ProductoPedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoPedidos_ProductoId",
                table: "ProductoPedidos",
                column: "ProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductoPedidos",
                table: "ProductoPedidos");

            migrationBuilder.DropIndex(
                name: "IX_ProductoPedidos_ProductoId",
                table: "ProductoPedidos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductoPedidos",
                table: "ProductoPedidos",
                columns: new[] { "ProductoId", "PedidoId" });
        }
    }
}
