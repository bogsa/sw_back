using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sw.Datos.Migrations
{
    /// <inheritdoc />
    public partial class _310324003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alm_Articulo_Alm_Categoria_E_CategoriaId",
                table: "Alm_Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Alm_Articulo_Conf_ProductoServicio_E_ProductoServicioId",
                table: "Alm_Articulo");

            migrationBuilder.AddColumn<int>(
                name: "E_ObjetoImpuestoId",
                table: "Alm_Articulo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "E_ProveedorId",
                table: "Alm_Articulo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "E_UnidadMedidaCId",
                table: "Alm_Articulo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "E_UnidadMedidaVId",
                table: "Alm_Articulo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Alm_Articulo_E_ObjetoImpuestoId",
                table: "Alm_Articulo",
                column: "E_ObjetoImpuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alm_Articulo_E_ProveedorId",
                table: "Alm_Articulo",
                column: "E_ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Alm_Articulo_E_UnidadMedidaCId",
                table: "Alm_Articulo",
                column: "E_UnidadMedidaCId");

            migrationBuilder.CreateIndex(
                name: "IX_Alm_Articulo_E_UnidadMedidaVId",
                table: "Alm_Articulo",
                column: "E_UnidadMedidaVId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alm_Articulo_Alm_Categoria_E_CategoriaId",
                table: "Alm_Articulo",
                column: "E_CategoriaId",
                principalTable: "Alm_Categoria",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Restrict);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Alm_Articulo_E_ObjetoImpuestoId",
                table: "Alm_Articulo");

            migrationBuilder.DropIndex(
                name: "IX_Alm_Articulo_E_ProveedorId",
                table: "Alm_Articulo");

            migrationBuilder.DropIndex(
                name: "IX_Alm_Articulo_E_UnidadMedidaCId",
                table: "Alm_Articulo");

            migrationBuilder.DropIndex(
                name: "IX_Alm_Articulo_E_UnidadMedidaVId",
                table: "Alm_Articulo");

            migrationBuilder.DropColumn(
                name: "E_ObjetoImpuestoId",
                table: "Alm_Articulo");

            migrationBuilder.DropColumn(
                name: "E_ProveedorId",
                table: "Alm_Articulo");

            migrationBuilder.DropColumn(
                name: "E_UnidadMedidaCId",
                table: "Alm_Articulo");

            migrationBuilder.DropColumn(
                name: "E_UnidadMedidaVId",
                table: "Alm_Articulo");

            migrationBuilder.AddForeignKey(
                name: "FK_Alm_Articulo_Alm_Categoria_E_CategoriaId",
                table: "Alm_Articulo",
                column: "E_CategoriaId",
                principalTable: "Alm_Categoria",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alm_Articulo_Conf_ProductoServicio_E_ProductoServicioId",
                table: "Alm_Articulo",
                column: "E_ProductoServicioId",
                principalTable: "Conf_ProductoServicio",
                principalColumn: "IdProductoServicio",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
