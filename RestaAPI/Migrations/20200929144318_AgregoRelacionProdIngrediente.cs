using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaAPI.Migrations
{
    public partial class AgregoRelacionProdIngrediente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_Productos_ProductoId",
                table: "Ingredientes");

            migrationBuilder.DropIndex(
                name: "IX_Ingredientes_ProductoId",
                table: "Ingredientes");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Ingredientes");

            migrationBuilder.CreateTable(
                name: "ProductoIngredientes",
                columns: table => new
                {
                    productoId = table.Column<int>(nullable: false),
                    ingredienteId = table.Column<int>(nullable: false),
                    ProductoIngredienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoIngredientes", x => new { x.ingredienteId, x.productoId });
                    table.ForeignKey(
                        name: "FK_ProductoIngredientes_Ingredientes_ingredienteId",
                        column: x => x.ingredienteId,
                        principalTable: "Ingredientes",
                        principalColumn: "IngredienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoIngredientes_Productos_productoId",
                        column: x => x.productoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductoIngredientes_productoId",
                table: "ProductoIngredientes",
                column: "productoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductoIngredientes");

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "Ingredientes",
                type: "int",
                nullable: true);

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
    }
}
