using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sw.Datos.Migrations
{
    /// <inheritdoc />
    public partial class _010724001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alm_Articulo_Alm_Categoria_E_CategoriaId",
                table: "Alm_Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Alm_Articulo_Cli_Proveedor_E_ProveedorId",
                table: "Alm_Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Alm_Articulo_Conf_ObjetoImpuesto_E_ObjetoImpuestoId",
                table: "Alm_Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Alm_Articulo_Conf_ProductoServicio_E_ProductoServicioId",
                table: "Alm_Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Alm_Articulo_Conf_UnidadMedida_E_UnidadMedidaCId",
                table: "Alm_Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Alm_Articulo_Conf_UnidadMedida_E_UnidadMedidaVId",
                table: "Alm_Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Alm_ArticuloDetalleImpuestos_Alm_Articulo_E_ArticuloId",
                table: "Alm_ArticuloDetalleImpuestos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alm_Categoria_Alm_Departamento_E_DepartamentoId",
                table: "Alm_Categoria");

            migrationBuilder.DropForeignKey(
                name: "FK_Alm_Departamento_Admin_Coorporativo_E_CorporativoId",
                table: "Alm_Departamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Alm_Inventario_Alm_Articulo_E_ArticuloId",
                table: "Alm_Inventario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alm_Departamento",
                table: "Alm_Departamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alm_Categoria",
                table: "Alm_Categoria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alm_ArticuloDetalleImpuestos",
                table: "Alm_ArticuloDetalleImpuestos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alm_Articulo",
                table: "Alm_Articulo");

            migrationBuilder.RenameTable(
                name: "Alm_Departamento",
                newName: "Art_Departamento");

            migrationBuilder.RenameTable(
                name: "Alm_Categoria",
                newName: "Art_Categoria");

            migrationBuilder.RenameTable(
                name: "Alm_ArticuloDetalleImpuestos",
                newName: "Art_ArticuloDetalleImpuestos");

            migrationBuilder.RenameTable(
                name: "Alm_Articulo",
                newName: "Art_Articulo");

            migrationBuilder.RenameIndex(
                name: "IX_Alm_Departamento_E_CorporativoId",
                table: "Art_Departamento",
                newName: "IX_Art_Departamento_E_CorporativoId");

            migrationBuilder.RenameIndex(
                name: "IX_Alm_Categoria_E_DepartamentoId",
                table: "Art_Categoria",
                newName: "IX_Art_Categoria_E_DepartamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Alm_ArticuloDetalleImpuestos_E_ArticuloId",
                table: "Art_ArticuloDetalleImpuestos",
                newName: "IX_Art_ArticuloDetalleImpuestos_E_ArticuloId");

            migrationBuilder.RenameIndex(
                name: "IX_Alm_Articulo_E_UnidadMedidaVId",
                table: "Art_Articulo",
                newName: "IX_Art_Articulo_E_UnidadMedidaVId");

            migrationBuilder.RenameIndex(
                name: "IX_Alm_Articulo_E_UnidadMedidaCId",
                table: "Art_Articulo",
                newName: "IX_Art_Articulo_E_UnidadMedidaCId");

            migrationBuilder.RenameIndex(
                name: "IX_Alm_Articulo_E_ProveedorId",
                table: "Art_Articulo",
                newName: "IX_Art_Articulo_E_ProveedorId");

            migrationBuilder.RenameIndex(
                name: "IX_Alm_Articulo_E_ProductoServicioId",
                table: "Art_Articulo",
                newName: "IX_Art_Articulo_E_ProductoServicioId");

            migrationBuilder.RenameIndex(
                name: "IX_Alm_Articulo_E_ObjetoImpuestoId",
                table: "Art_Articulo",
                newName: "IX_Art_Articulo_E_ObjetoImpuestoId");

            migrationBuilder.RenameIndex(
                name: "IX_Alm_Articulo_E_CategoriaId",
                table: "Art_Articulo",
                newName: "IX_Art_Articulo_E_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Art_Departamento",
                table: "Art_Departamento",
                column: "IdDepartamento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Art_Categoria",
                table: "Art_Categoria",
                column: "IdCategoria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Art_ArticuloDetalleImpuestos",
                table: "Art_ArticuloDetalleImpuestos",
                column: "IdArticuloDetalleImpuestos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Art_Articulo",
                table: "Art_Articulo",
                column: "IdArticulo");

            migrationBuilder.AddForeignKey(
                name: "FK_Alm_Inventario_Art_Articulo_E_ArticuloId",
                table: "Alm_Inventario",
                column: "E_ArticuloId",
                principalTable: "Art_Articulo",
                principalColumn: "IdArticulo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Art_Articulo_Art_Categoria_E_CategoriaId",
                table: "Art_Articulo",
                column: "E_CategoriaId",
                principalTable: "Art_Categoria",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Art_Articulo_Cli_Proveedor_E_ProveedorId",
                table: "Art_Articulo",
                column: "E_ProveedorId",
                principalTable: "Cli_Proveedor",
                principalColumn: "IdProveedor",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Art_Articulo_Conf_ObjetoImpuesto_E_ObjetoImpuestoId",
                table: "Art_Articulo",
                column: "E_ObjetoImpuestoId",
                principalTable: "Conf_ObjetoImpuesto",
                principalColumn: "IdObjetoImpuesto",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Art_Articulo_Conf_ProductoServicio_E_ProductoServicioId",
                table: "Art_Articulo",
                column: "E_ProductoServicioId",
                principalTable: "Conf_ProductoServicio",
                principalColumn: "IdProductoServicio",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Art_Articulo_Conf_UnidadMedida_E_UnidadMedidaCId",
                table: "Art_Articulo",
                column: "E_UnidadMedidaCId",
                principalTable: "Conf_UnidadMedida",
                principalColumn: "IdUnidadMedida",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Art_Articulo_Conf_UnidadMedida_E_UnidadMedidaVId",
                table: "Art_Articulo",
                column: "E_UnidadMedidaVId",
                principalTable: "Conf_UnidadMedida",
                principalColumn: "IdUnidadMedida",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Art_ArticuloDetalleImpuestos_Art_Articulo_E_ArticuloId",
                table: "Art_ArticuloDetalleImpuestos",
                column: "E_ArticuloId",
                principalTable: "Art_Articulo",
                principalColumn: "IdArticulo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Art_Categoria_Art_Departamento_E_DepartamentoId",
                table: "Art_Categoria",
                column: "E_DepartamentoId",
                principalTable: "Art_Departamento",
                principalColumn: "IdDepartamento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Art_Departamento_Admin_Coorporativo_E_CorporativoId",
                table: "Art_Departamento",
                column: "E_CorporativoId",
                principalTable: "Admin_Coorporativo",
                principalColumn: "IdCoorporativo",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alm_Inventario_Art_Articulo_E_ArticuloId",
                table: "Alm_Inventario");

            migrationBuilder.DropForeignKey(
                name: "FK_Art_Articulo_Art_Categoria_E_CategoriaId",
                table: "Art_Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Art_Articulo_Cli_Proveedor_E_ProveedorId",
                table: "Art_Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Art_Articulo_Conf_ObjetoImpuesto_E_ObjetoImpuestoId",
                table: "Art_Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Art_Articulo_Conf_ProductoServicio_E_ProductoServicioId",
                table: "Art_Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Art_Articulo_Conf_UnidadMedida_E_UnidadMedidaCId",
                table: "Art_Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Art_Articulo_Conf_UnidadMedida_E_UnidadMedidaVId",
                table: "Art_Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Art_ArticuloDetalleImpuestos_Art_Articulo_E_ArticuloId",
                table: "Art_ArticuloDetalleImpuestos");

            migrationBuilder.DropForeignKey(
                name: "FK_Art_Categoria_Art_Departamento_E_DepartamentoId",
                table: "Art_Categoria");

            migrationBuilder.DropForeignKey(
                name: "FK_Art_Departamento_Admin_Coorporativo_E_CorporativoId",
                table: "Art_Departamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Art_Departamento",
                table: "Art_Departamento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Art_Categoria",
                table: "Art_Categoria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Art_ArticuloDetalleImpuestos",
                table: "Art_ArticuloDetalleImpuestos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Art_Articulo",
                table: "Art_Articulo");

            migrationBuilder.RenameTable(
                name: "Art_Departamento",
                newName: "Alm_Departamento");

            migrationBuilder.RenameTable(
                name: "Art_Categoria",
                newName: "Alm_Categoria");

            migrationBuilder.RenameTable(
                name: "Art_ArticuloDetalleImpuestos",
                newName: "Alm_ArticuloDetalleImpuestos");

            migrationBuilder.RenameTable(
                name: "Art_Articulo",
                newName: "Alm_Articulo");

            migrationBuilder.RenameIndex(
                name: "IX_Art_Departamento_E_CorporativoId",
                table: "Alm_Departamento",
                newName: "IX_Alm_Departamento_E_CorporativoId");

            migrationBuilder.RenameIndex(
                name: "IX_Art_Categoria_E_DepartamentoId",
                table: "Alm_Categoria",
                newName: "IX_Alm_Categoria_E_DepartamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Art_ArticuloDetalleImpuestos_E_ArticuloId",
                table: "Alm_ArticuloDetalleImpuestos",
                newName: "IX_Alm_ArticuloDetalleImpuestos_E_ArticuloId");

            migrationBuilder.RenameIndex(
                name: "IX_Art_Articulo_E_UnidadMedidaVId",
                table: "Alm_Articulo",
                newName: "IX_Alm_Articulo_E_UnidadMedidaVId");

            migrationBuilder.RenameIndex(
                name: "IX_Art_Articulo_E_UnidadMedidaCId",
                table: "Alm_Articulo",
                newName: "IX_Alm_Articulo_E_UnidadMedidaCId");

            migrationBuilder.RenameIndex(
                name: "IX_Art_Articulo_E_ProveedorId",
                table: "Alm_Articulo",
                newName: "IX_Alm_Articulo_E_ProveedorId");

            migrationBuilder.RenameIndex(
                name: "IX_Art_Articulo_E_ProductoServicioId",
                table: "Alm_Articulo",
                newName: "IX_Alm_Articulo_E_ProductoServicioId");

            migrationBuilder.RenameIndex(
                name: "IX_Art_Articulo_E_ObjetoImpuestoId",
                table: "Alm_Articulo",
                newName: "IX_Alm_Articulo_E_ObjetoImpuestoId");

            migrationBuilder.RenameIndex(
                name: "IX_Art_Articulo_E_CategoriaId",
                table: "Alm_Articulo",
                newName: "IX_Alm_Articulo_E_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alm_Departamento",
                table: "Alm_Departamento",
                column: "IdDepartamento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alm_Categoria",
                table: "Alm_Categoria",
                column: "IdCategoria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alm_ArticuloDetalleImpuestos",
                table: "Alm_ArticuloDetalleImpuestos",
                column: "IdArticuloDetalleImpuestos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alm_Articulo",
                table: "Alm_Articulo",
                column: "IdArticulo");

            migrationBuilder.AddForeignKey(
                name: "FK_Alm_Articulo_Alm_Categoria_E_CategoriaId",
                table: "Alm_Articulo",
                column: "E_CategoriaId",
                principalTable: "Alm_Categoria",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alm_Articulo_Cli_Proveedor_E_ProveedorId",
                table: "Alm_Articulo",
                column: "E_ProveedorId",
                principalTable: "Cli_Proveedor",
                principalColumn: "IdProveedor",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alm_Articulo_Conf_ObjetoImpuesto_E_ObjetoImpuestoId",
                table: "Alm_Articulo",
                column: "E_ObjetoImpuestoId",
                principalTable: "Conf_ObjetoImpuesto",
                principalColumn: "IdObjetoImpuesto",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alm_Articulo_Conf_ProductoServicio_E_ProductoServicioId",
                table: "Alm_Articulo",
                column: "E_ProductoServicioId",
                principalTable: "Conf_ProductoServicio",
                principalColumn: "IdProductoServicio",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alm_Articulo_Conf_UnidadMedida_E_UnidadMedidaCId",
                table: "Alm_Articulo",
                column: "E_UnidadMedidaCId",
                principalTable: "Conf_UnidadMedida",
                principalColumn: "IdUnidadMedida",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alm_Articulo_Conf_UnidadMedida_E_UnidadMedidaVId",
                table: "Alm_Articulo",
                column: "E_UnidadMedidaVId",
                principalTable: "Conf_UnidadMedida",
                principalColumn: "IdUnidadMedida",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alm_ArticuloDetalleImpuestos_Alm_Articulo_E_ArticuloId",
                table: "Alm_ArticuloDetalleImpuestos",
                column: "E_ArticuloId",
                principalTable: "Alm_Articulo",
                principalColumn: "IdArticulo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alm_Categoria_Alm_Departamento_E_DepartamentoId",
                table: "Alm_Categoria",
                column: "E_DepartamentoId",
                principalTable: "Alm_Departamento",
                principalColumn: "IdDepartamento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alm_Departamento_Admin_Coorporativo_E_CorporativoId",
                table: "Alm_Departamento",
                column: "E_CorporativoId",
                principalTable: "Admin_Coorporativo",
                principalColumn: "IdCoorporativo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alm_Inventario_Alm_Articulo_E_ArticuloId",
                table: "Alm_Inventario",
                column: "E_ArticuloId",
                principalTable: "Alm_Articulo",
                principalColumn: "IdArticulo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
