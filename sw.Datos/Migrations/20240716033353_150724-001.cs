using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sw.Datos.Migrations
{
    /// <inheritdoc />
    public partial class _150724001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alm_Inventario_Art_Articulo_E_ArticuloId",
                table: "Alm_Inventario");

            migrationBuilder.DropTable(
                name: "Art_ArticuloDetalleImpuestos");

            migrationBuilder.DropTable(
                name: "Art_Articulo");

            migrationBuilder.DropTable(
                name: "Art_Categoria");

            migrationBuilder.DropTable(
                name: "Art_Departamento");

            migrationBuilder.RenameColumn(
                name: "E_ArticuloId",
                table: "Alm_Inventario",
                newName: "E_ProductoId");

            migrationBuilder.RenameIndex(
                name: "IX_Alm_Inventario_E_ArticuloId",
                table: "Alm_Inventario",
                newName: "IX_Alm_Inventario_E_ProductoId");

            migrationBuilder.CreateTable(
                name: "Pro_Departamento",
                columns: table => new
                {
                    IdDepartamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    E_CorporativoId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pro_Departamento", x => x.IdDepartamento);
                    table.ForeignKey(
                        name: "FK_Pro_Departamento_Admin_Coorporativo_E_CorporativoId",
                        column: x => x.E_CorporativoId,
                        principalTable: "Admin_Coorporativo",
                        principalColumn: "IdCoorporativo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pro_Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pro_Categoria", x => x.IdCategoria);
                    table.ForeignKey(
                        name: "FK_Pro_Categoria_Pro_Departamento_E_DepartamentoId",
                        column: x => x.E_DepartamentoId,
                        principalTable: "Pro_Departamento",
                        principalColumn: "IdDepartamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pro_Producto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentificadorUnico = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoBarras = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreArticulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescripcionArticulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    E_ProductoServicioId = table.Column<int>(type: "int", nullable: false),
                    E_CategoriaId = table.Column<int>(type: "int", nullable: false),
                    Localizacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    E_ProveedorId = table.Column<int>(type: "int", nullable: false),
                    E_UnidadMedidaCId = table.Column<int>(type: "int", nullable: false),
                    E_UnidadMedidaVId = table.Column<int>(type: "int", nullable: false),
                    PrecioCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Factor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    E_ObjetoImpuestoId = table.Column<int>(type: "int", nullable: false),
                    CuentaPredial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusServicio = table.Column<bool>(type: "bit", nullable: false),
                    ControlaExistencias = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    StatusProduccion = table.Column<bool>(type: "bit", nullable: false),
                    LotesCaducidades = table.Column<bool>(type: "bit", nullable: false),
                    Receta = table.Column<bool>(type: "bit", nullable: false),
                    NumerosSerie = table.Column<bool>(type: "bit", nullable: false),
                    Corrida = table.Column<bool>(type: "bit", nullable: false),
                    Paquete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pro_Producto", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Pro_Producto_Cli_Proveedor_E_ProveedorId",
                        column: x => x.E_ProveedorId,
                        principalTable: "Cli_Proveedor",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pro_Producto_Conf_ObjetoImpuesto_E_ObjetoImpuestoId",
                        column: x => x.E_ObjetoImpuestoId,
                        principalTable: "Conf_ObjetoImpuesto",
                        principalColumn: "IdObjetoImpuesto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pro_Producto_Conf_ProductoServicio_E_ProductoServicioId",
                        column: x => x.E_ProductoServicioId,
                        principalTable: "Conf_ProductoServicio",
                        principalColumn: "IdProductoServicio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pro_Producto_Conf_UnidadMedida_E_UnidadMedidaCId",
                        column: x => x.E_UnidadMedidaCId,
                        principalTable: "Conf_UnidadMedida",
                        principalColumn: "IdUnidadMedida",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pro_Producto_Conf_UnidadMedida_E_UnidadMedidaVId",
                        column: x => x.E_UnidadMedidaVId,
                        principalTable: "Conf_UnidadMedida",
                        principalColumn: "IdUnidadMedida",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pro_Producto_Pro_Categoria_E_CategoriaId",
                        column: x => x.E_CategoriaId,
                        principalTable: "Pro_Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pro_ProductoDetalleImpuestos",
                columns: table => new
                {
                    IdProductoDetalleImpuestos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_ProductoId = table.Column<int>(type: "int", nullable: false),
                    TipoImpuesto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Impuesto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoFactor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pro_ProductoDetalleImpuestos", x => x.IdProductoDetalleImpuestos);
                    table.ForeignKey(
                        name: "FK_Pro_ProductoDetalleImpuestos_Pro_Producto_E_ProductoId",
                        column: x => x.E_ProductoId,
                        principalTable: "Pro_Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pro_Categoria_E_DepartamentoId",
                table: "Pro_Categoria",
                column: "E_DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pro_Departamento_E_CorporativoId",
                table: "Pro_Departamento",
                column: "E_CorporativoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pro_Producto_E_CategoriaId",
                table: "Pro_Producto",
                column: "E_CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pro_Producto_E_ObjetoImpuestoId",
                table: "Pro_Producto",
                column: "E_ObjetoImpuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pro_Producto_E_ProductoServicioId",
                table: "Pro_Producto",
                column: "E_ProductoServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pro_Producto_E_ProveedorId",
                table: "Pro_Producto",
                column: "E_ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pro_Producto_E_UnidadMedidaCId",
                table: "Pro_Producto",
                column: "E_UnidadMedidaCId");

            migrationBuilder.CreateIndex(
                name: "IX_Pro_Producto_E_UnidadMedidaVId",
                table: "Pro_Producto",
                column: "E_UnidadMedidaVId");

            migrationBuilder.CreateIndex(
                name: "IX_Pro_ProductoDetalleImpuestos_E_ProductoId",
                table: "Pro_ProductoDetalleImpuestos",
                column: "E_ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alm_Inventario_Pro_Producto_E_ProductoId",
                table: "Alm_Inventario",
                column: "E_ProductoId",
                principalTable: "Pro_Producto",
                principalColumn: "IdProducto",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alm_Inventario_Pro_Producto_E_ProductoId",
                table: "Alm_Inventario");

            migrationBuilder.DropTable(
                name: "Pro_ProductoDetalleImpuestos");

            migrationBuilder.DropTable(
                name: "Pro_Producto");

            migrationBuilder.DropTable(
                name: "Pro_Categoria");

            migrationBuilder.DropTable(
                name: "Pro_Departamento");

            migrationBuilder.RenameColumn(
                name: "E_ProductoId",
                table: "Alm_Inventario",
                newName: "E_ArticuloId");

            migrationBuilder.RenameIndex(
                name: "IX_Alm_Inventario_E_ProductoId",
                table: "Alm_Inventario",
                newName: "IX_Alm_Inventario_E_ArticuloId");

            migrationBuilder.CreateTable(
                name: "Art_Departamento",
                columns: table => new
                {
                    IdDepartamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_CorporativoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Art_Departamento", x => x.IdDepartamento);
                    table.ForeignKey(
                        name: "FK_Art_Departamento_Admin_Coorporativo_E_CorporativoId",
                        column: x => x.E_CorporativoId,
                        principalTable: "Admin_Coorporativo",
                        principalColumn: "IdCoorporativo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Art_Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Art_Categoria", x => x.IdCategoria);
                    table.ForeignKey(
                        name: "FK_Art_Categoria_Art_Departamento_E_DepartamentoId",
                        column: x => x.E_DepartamentoId,
                        principalTable: "Art_Departamento",
                        principalColumn: "IdDepartamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Art_Articulo",
                columns: table => new
                {
                    IdArticulo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_CategoriaId = table.Column<int>(type: "int", nullable: false),
                    E_ObjetoImpuestoId = table.Column<int>(type: "int", nullable: false),
                    E_ProductoServicioId = table.Column<int>(type: "int", nullable: false),
                    E_ProveedorId = table.Column<int>(type: "int", nullable: false),
                    E_UnidadMedidaCId = table.Column<int>(type: "int", nullable: false),
                    E_UnidadMedidaVId = table.Column<int>(type: "int", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoBarras = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControlaExistencias = table.Column<bool>(type: "bit", nullable: false),
                    Corrida = table.Column<bool>(type: "bit", nullable: false),
                    CuentaPredial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescripcionArticulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Factor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdentificadorUnico = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Localizacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LotesCaducidades = table.Column<bool>(type: "bit", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreArticulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumerosSerie = table.Column<bool>(type: "bit", nullable: false),
                    Paquete = table.Column<bool>(type: "bit", nullable: false),
                    PrecioCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Receta = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    StatusProduccion = table.Column<bool>(type: "bit", nullable: false),
                    StatusServicio = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Art_Articulo", x => x.IdArticulo);
                    table.ForeignKey(
                        name: "FK_Art_Articulo_Art_Categoria_E_CategoriaId",
                        column: x => x.E_CategoriaId,
                        principalTable: "Art_Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Art_Articulo_Cli_Proveedor_E_ProveedorId",
                        column: x => x.E_ProveedorId,
                        principalTable: "Cli_Proveedor",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Art_Articulo_Conf_ObjetoImpuesto_E_ObjetoImpuestoId",
                        column: x => x.E_ObjetoImpuestoId,
                        principalTable: "Conf_ObjetoImpuesto",
                        principalColumn: "IdObjetoImpuesto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Art_Articulo_Conf_ProductoServicio_E_ProductoServicioId",
                        column: x => x.E_ProductoServicioId,
                        principalTable: "Conf_ProductoServicio",
                        principalColumn: "IdProductoServicio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Art_Articulo_Conf_UnidadMedida_E_UnidadMedidaCId",
                        column: x => x.E_UnidadMedidaCId,
                        principalTable: "Conf_UnidadMedida",
                        principalColumn: "IdUnidadMedida",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Art_Articulo_Conf_UnidadMedida_E_UnidadMedidaVId",
                        column: x => x.E_UnidadMedidaVId,
                        principalTable: "Conf_UnidadMedida",
                        principalColumn: "IdUnidadMedida",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Art_ArticuloDetalleImpuestos",
                columns: table => new
                {
                    IdArticuloDetalleImpuestos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    E_ArticuloId = table.Column<int>(type: "int", nullable: false),
                    Impuesto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoFactor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoImpuesto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Art_ArticuloDetalleImpuestos", x => x.IdArticuloDetalleImpuestos);
                    table.ForeignKey(
                        name: "FK_Art_ArticuloDetalleImpuestos_Art_Articulo_E_ArticuloId",
                        column: x => x.E_ArticuloId,
                        principalTable: "Art_Articulo",
                        principalColumn: "IdArticulo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Art_Articulo_E_CategoriaId",
                table: "Art_Articulo",
                column: "E_CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Art_Articulo_E_ObjetoImpuestoId",
                table: "Art_Articulo",
                column: "E_ObjetoImpuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_Art_Articulo_E_ProductoServicioId",
                table: "Art_Articulo",
                column: "E_ProductoServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Art_Articulo_E_ProveedorId",
                table: "Art_Articulo",
                column: "E_ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Art_Articulo_E_UnidadMedidaCId",
                table: "Art_Articulo",
                column: "E_UnidadMedidaCId");

            migrationBuilder.CreateIndex(
                name: "IX_Art_Articulo_E_UnidadMedidaVId",
                table: "Art_Articulo",
                column: "E_UnidadMedidaVId");

            migrationBuilder.CreateIndex(
                name: "IX_Art_ArticuloDetalleImpuestos_E_ArticuloId",
                table: "Art_ArticuloDetalleImpuestos",
                column: "E_ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_Art_Categoria_E_DepartamentoId",
                table: "Art_Categoria",
                column: "E_DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Art_Departamento_E_CorporativoId",
                table: "Art_Departamento",
                column: "E_CorporativoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alm_Inventario_Art_Articulo_E_ArticuloId",
                table: "Alm_Inventario",
                column: "E_ArticuloId",
                principalTable: "Art_Articulo",
                principalColumn: "IdArticulo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
