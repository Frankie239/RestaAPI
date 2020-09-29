using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaAPI.Migrations
{
    public partial class agregoPedidoAMesa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Mozos_VendedorId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_VendedorId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "VendedorId",
                table: "Pedidos");

            migrationBuilder.AddColumn<string>(
                name: "MozoId",
                table: "Pedidos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_MozoId",
                table: "Pedidos",
                column: "MozoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Mozos_MozoId",
                table: "Pedidos",
                column: "MozoId",
                principalTable: "Mozos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Mozos_MozoId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_MozoId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "MozoId",
                table: "Pedidos");

            migrationBuilder.AddColumn<string>(
                name: "VendedorId",
                table: "Pedidos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_VendedorId",
                table: "Pedidos",
                column: "VendedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Mozos_VendedorId",
                table: "Pedidos",
                column: "VendedorId",
                principalTable: "Mozos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
