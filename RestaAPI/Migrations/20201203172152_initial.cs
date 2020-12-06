using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MedioDePagoPreferido = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    IngredienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.IngredienteId);
                });

            migrationBuilder.CreateTable(
                name: "Mesas",
                columns: table => new
                {
                    MesaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDeMesa = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesas", x => x.MesaId);
                });

            migrationBuilder.CreateTable(
                name: "Mozos",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Salario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mozos", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<string>(nullable: true),
                    MesaId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    MozoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK_Pedidos_clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedidos_Mesas_MesaId",
                        column: x => x.MesaId,
                        principalTable: "Mesas",
                        principalColumn: "MesaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Mozos_MozoId",
                        column: x => x.MozoId,
                        principalTable: "Mozos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "ProductoPedidos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(nullable: false),
                    PedidoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoPedidos", x => new { x.ProductoId, x.PedidoId });
                    table.ForeignKey(
                        name: "FK_ProductoPedidos_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoPedidos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_MesaId",
                table: "Pedidos",
                column: "MesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_MozoId",
                table: "Pedidos",
                column: "MozoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoIngredientes_productoId",
                table: "ProductoIngredientes",
                column: "productoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoPedidos_PedidoId",
                table: "ProductoPedidos",
                column: "PedidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductoIngredientes");

            migrationBuilder.DropTable(
                name: "ProductoPedidos");

            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "Mesas");

            migrationBuilder.DropTable(
                name: "Mozos");
        }
    }
}
