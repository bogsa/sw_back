using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sw.Datos.Migrations
{
    /// <inheritdoc />
    public partial class _170724001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alm_InventarioDetallePrecios");

            migrationBuilder.RenameColumn(
                name: "NombreArticulo",
                table: "Pro_Producto",
                newName: "NombreProducto");

            migrationBuilder.RenameColumn(
                name: "DescripcionArticulo",
                table: "Pro_Producto",
                newName: "DescripcionProducto");

            migrationBuilder.CreateTable(
                name: "Pro_ProductoDetallePrecios",
                columns: table => new
                {
                    IdProductoDetallePrecios = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_ProductoId = table.Column<int>(type: "int", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CantidadMayor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CantidadMenor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MargenUtilidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pro_ProductoDetallePrecios", x => x.IdProductoDetallePrecios);
                    table.ForeignKey(
                        name: "FK_Pro_ProductoDetallePrecios_Pro_Producto_E_ProductoId",
                        column: x => x.E_ProductoId,
                        principalTable: "Pro_Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pro_ProductoDetallePrecios_E_ProductoId",
                table: "Pro_ProductoDetallePrecios",
                column: "E_ProductoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pro_ProductoDetallePrecios");

            migrationBuilder.RenameColumn(
                name: "NombreProducto",
                table: "Pro_Producto",
                newName: "NombreArticulo");

            migrationBuilder.RenameColumn(
                name: "DescripcionProducto",
                table: "Pro_Producto",
                newName: "DescripcionArticulo");

            migrationBuilder.CreateTable(
                name: "Alm_InventarioDetallePrecios",
                columns: table => new
                {
                    IdInventarioDetallePrecios = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_InventarioId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MargenUtilidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alm_InventarioDetallePrecios", x => x.IdInventarioDetallePrecios);
                    table.ForeignKey(
                        name: "FK_Alm_InventarioDetallePrecios_Alm_Inventario_E_InventarioId",
                        column: x => x.E_InventarioId,
                        principalTable: "Alm_Inventario",
                        principalColumn: "IdInventario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alm_InventarioDetallePrecios_E_InventarioId",
                table: "Alm_InventarioDetallePrecios",
                column: "E_InventarioId");
        }
    }
}
