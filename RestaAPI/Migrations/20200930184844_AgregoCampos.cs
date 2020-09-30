using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaAPI.Migrations
{
    public partial class AgregoCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_clientes_compradorId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_compradorId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "compradorId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "mesa",
                table: "Pedidos");

            migrationBuilder.AddColumn<string>(
                name: "ClienteId",
                table: "Pedidos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_clientes_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                principalTable: "clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_clientes_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Pedidos");

            migrationBuilder.AddColumn<string>(
                name: "compradorId",
                table: "Pedidos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "mesa",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_compradorId",
                table: "Pedidos",
                column: "compradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_clientes_compradorId",
                table: "Pedidos",
                column: "compradorId",
                principalTable: "clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
