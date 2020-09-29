using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaAPI.Migrations
{
    public partial class AgregoProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "Ingredientes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Precio = table.Column<double>(nullable: false),
                    Tipo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_ProductoId",
                table: "Ingredientes",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_Productos_ProductoId",
                table: "Ingredientes",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "ProductoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_Productos_ProductoId",
                table: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Ingredientes_ProductoId",
                table: "Ingredientes");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Ingredientes");
        }
    }
}
