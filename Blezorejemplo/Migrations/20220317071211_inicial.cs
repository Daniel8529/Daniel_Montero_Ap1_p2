using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blezorejemplo.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Existencia = table.Column<int>(type: "INTEGER", nullable: false),
                    Costo = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorInventario = table.Column<float>(type: "REAL", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false),
                    FechaCaducacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Gramo = table.Column<float>(type: "REAL", nullable: false),
                    Ganancia = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "productospaquetes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Concepto = table.Column<string>(type: "TEXT", nullable: true),
                    FechaCaducacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    total = table.Column<float>(type: "REAL", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productospaquetes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductosDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Presentacion = table.Column<string>(type: "TEXT", nullable: true),
                    Precio = table.Column<float>(type: "REAL", nullable: false),
                    cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Existenciaempaquetado = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductosDetalle_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productoparaayuda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    descricion = table.Column<string>(type: "TEXT", nullable: true),
                    Concepto = table.Column<string>(type: "TEXT", nullable: true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductospaqueteId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productoparaayuda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productoparaayuda_productospaquetes_ProductospaqueteId",
                        column: x => x.ProductospaqueteId,
                        principalTable: "productospaquetes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productoparaayuda_ProductospaqueteId",
                table: "Productoparaayuda",
                column: "ProductospaqueteId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosDetalle_ProductoId",
                table: "ProductosDetalle",
                column: "ProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productoparaayuda");

            migrationBuilder.DropTable(
                name: "ProductosDetalle");

            migrationBuilder.DropTable(
                name: "productospaquetes");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
