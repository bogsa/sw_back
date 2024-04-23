using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sw.Datos.Migrations
{
    /// <inheritdoc />
    public partial class _310324002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AD_ASIGNACIONTFD_AD_EMPRESA_E_EmpresaId",
                table: "AD_ASIGNACIONTFD");

            migrationBuilder.DropForeignKey(
                name: "FK_AD_CENTROTRABAJO_AD_EMPRESA_E_EmpresaId",
                table: "AD_CENTROTRABAJO");

            migrationBuilder.DropForeignKey(
                name: "FK_AD_EMPRESA_AD_COORPORATIVO_E_CoorporativoId",
                table: "AD_EMPRESA");

            migrationBuilder.DropForeignKey(
                name: "FK_AD_EMPRESA_CO_REGIMENFISCAL_E_RegimenFiscalId",
                table: "AD_EMPRESA");

            migrationBuilder.DropForeignKey(
                name: "FK_AD_MODULO_AD_PERFIL_E_PerfilId",
                table: "AD_MODULO");

            migrationBuilder.DropForeignKey(
                name: "FK_AD_MODULO_AspNetRoles_RolId",
                table: "AD_MODULO");

            migrationBuilder.DropForeignKey(
                name: "FK_AD_PERMISO_AD_MODULO_E_ModuloId",
                table: "AD_PERMISO");

            migrationBuilder.DropForeignKey(
                name: "FK_AD_PERMISO_AspNetRoleClaims_ClaimId",
                table: "AD_PERMISO");

            migrationBuilder.DropForeignKey(
                name: "FK_AD_SUBMENU_AD_MENU_MenuId",
                table: "AD_SUBMENU");

            migrationBuilder.DropForeignKey(
                name: "FK_AD_TFDsDETALLE_AD_TFDsGLOBAL_E_TFDsGlobalId",
                table: "AD_TFDsDETALLE");

            migrationBuilder.DropForeignKey(
                name: "FK_AD_USUARIOCENTROTRABAJO_AD_CENTROTRABAJO_E_CentroTrabajoId",
                table: "AD_USUARIOCENTROTRABAJO");

            migrationBuilder.DropForeignKey(
                name: "FK_AD_USUARIOCENTROTRABAJO_AspNetUsers_UserId",
                table: "AD_USUARIOCENTROTRABAJO");

            migrationBuilder.DropForeignKey(
                name: "FK_AD_USUARIOEMPRESAS_AD_EMPRESA_E_EmpresaId",
                table: "AD_USUARIOEMPRESAS");

            migrationBuilder.DropForeignKey(
                name: "FK_AD_USUARIOEMPRESAS_AspNetUsers_UserId",
                table: "AD_USUARIOEMPRESAS");

            migrationBuilder.DropForeignKey(
                name: "FK_AL_ARTICULO_AL_CATEGORIA_E_CategoriaId",
                table: "AL_ARTICULO");

            migrationBuilder.DropForeignKey(
                name: "FK_AL_ARTICULO_CO_PRODUCTOSERVICIO_E_ProductoServicioId",
                table: "AL_ARTICULO");

            migrationBuilder.DropForeignKey(
                name: "FK_AL_ARTICULO_DETALLE_IMPUESTOS_AL_ARTICULO_E_ArticuloId",
                table: "AL_ARTICULO_DETALLE_IMPUESTOS");

            migrationBuilder.DropForeignKey(
                name: "FK_AL_CATEGORIA_AL_DEPARTAMENTO_E_DepartamentoId",
                table: "AL_CATEGORIA");

            migrationBuilder.DropForeignKey(
                name: "FK_AL_DEPARTAMENTO_AD_COORPORATIVO_E_CorporativoId",
                table: "AL_DEPARTAMENTO");

            migrationBuilder.DropForeignKey(
                name: "FK_AL_INVENTARIO_AD_CENTROTRABAJO_E_CentroTrabajoId",
                table: "AL_INVENTARIO");

            migrationBuilder.DropForeignKey(
                name: "FK_AL_INVENTARIO_DETALLE_PRECIOS_AL_INVENTARIO_E_InventarioId",
                table: "AL_INVENTARIO_DETALLE_PRECIOS");

            migrationBuilder.DropForeignKey(
                name: "FK_AL_MARCA_AD_COORPORATIVO_E_CorporativoId",
                table: "AL_MARCA");

            migrationBuilder.DropForeignKey(
                name: "FK_AL_PROVEEDOR_AD_COORPORATIVO_E_CorporativoId",
                table: "AL_PROVEEDOR");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AD_CENTROTRABAJO_E_CentroTrabajoId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CL_CLIENTES_AD_COORPORATIVO_E_CoorporativoId",
                table: "CL_CLIENTES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CO_USOCFDI",
                table: "CO_USOCFDI");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CO_UNIDADMEDIDA",
                table: "CO_UNIDADMEDIDA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CO_TIPORELACION",
                table: "CO_TIPORELACION");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CO_TIPOFACTOR",
                table: "CO_TIPOFACTOR");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CO_TIPOCOMPROBANTE",
                table: "CO_TIPOCOMPROBANTE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CO_REGIMENFISCAL",
                table: "CO_REGIMENFISCAL");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CO_PRODUCTOSERVICIO",
                table: "CO_PRODUCTOSERVICIO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CO_OBJETOIMPUESTO",
                table: "CO_OBJETOIMPUESTO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CO_MONEDA",
                table: "CO_MONEDA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CO_METODOPAGO",
                table: "CO_METODOPAGO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CO_IMPUESTO",
                table: "CO_IMPUESTO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CO_FORMAPAGO",
                table: "CO_FORMAPAGO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CL_CLIENTES",
                table: "CL_CLIENTES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AL_PROVEEDOR",
                table: "AL_PROVEEDOR");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AL_MARCA",
                table: "AL_MARCA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AL_INVENTARIO_DETALLE_PRECIOS",
                table: "AL_INVENTARIO_DETALLE_PRECIOS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AL_INVENTARIO",
                table: "AL_INVENTARIO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AL_DEPARTAMENTO",
                table: "AL_DEPARTAMENTO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AL_CATEGORIA",
                table: "AL_CATEGORIA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AL_ARTICULO_DETALLE_IMPUESTOS",
                table: "AL_ARTICULO_DETALLE_IMPUESTOS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AL_ARTICULO",
                table: "AL_ARTICULO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AD_USUARIOEMPRESAS",
                table: "AD_USUARIOEMPRESAS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AD_USUARIOCENTROTRABAJO",
                table: "AD_USUARIOCENTROTRABAJO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AD_TFDsGLOBAL",
                table: "AD_TFDsGLOBAL");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AD_TFDsDETALLE",
                table: "AD_TFDsDETALLE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AD_SUBMENU",
                table: "AD_SUBMENU");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AD_PERMISO",
                table: "AD_PERMISO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AD_PERFIL",
                table: "AD_PERFIL");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AD_MODULO",
                table: "AD_MODULO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AD_MENU",
                table: "AD_MENU");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AD_EMPRESA",
                table: "AD_EMPRESA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AD_COORPORATIVO",
                table: "AD_COORPORATIVO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AD_CENTROTRABAJO",
                table: "AD_CENTROTRABAJO");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AD_ASIGNACIONTFD",
                table: "AD_ASIGNACIONTFD");

            migrationBuilder.RenameTable(
                name: "CO_USOCFDI",
                newName: "Conf_UsoCFDI");

            migrationBuilder.RenameTable(
                name: "CO_UNIDADMEDIDA",
                newName: "Conf_UnidadMedida");

            migrationBuilder.RenameTable(
                name: "CO_TIPORELACION",
                newName: "Conf_TipoRelacion");

            migrationBuilder.RenameTable(
                name: "CO_TIPOFACTOR",
                newName: "Conf_TipoFactor");

            migrationBuilder.RenameTable(
                name: "CO_TIPOCOMPROBANTE",
                newName: "Conf_TipoComprobante");

            migrationBuilder.RenameTable(
                name: "CO_REGIMENFISCAL",
                newName: "Conf_RegimenFiscal");

            migrationBuilder.RenameTable(
                name: "CO_PRODUCTOSERVICIO",
                newName: "Conf_ProductoServicio");

            migrationBuilder.RenameTable(
                name: "CO_OBJETOIMPUESTO",
                newName: "Conf_ObjetoImpuesto");

            migrationBuilder.RenameTable(
                name: "CO_MONEDA",
                newName: "Conf_Moneda");

            migrationBuilder.RenameTable(
                name: "CO_METODOPAGO",
                newName: "Conf_MetodoPago");

            migrationBuilder.RenameTable(
                name: "CO_IMPUESTO",
                newName: "Conf_Impuesto");

            migrationBuilder.RenameTable(
                name: "CO_FORMAPAGO",
                newName: "Conf_FormaPago");

            migrationBuilder.RenameTable(
                name: "CL_CLIENTES",
                newName: "Cli_Clientes");

            migrationBuilder.RenameTable(
                name: "AL_PROVEEDOR",
                newName: "Cli_Proveedor");

            migrationBuilder.RenameTable(
                name: "AL_MARCA",
                newName: "Cli_Marca");

            migrationBuilder.RenameTable(
                name: "AL_INVENTARIO_DETALLE_PRECIOS",
                newName: "Alm_InventarioDetallePrecios");

            migrationBuilder.RenameTable(
                name: "AL_INVENTARIO",
                newName: "Alm_Inventario");

            migrationBuilder.RenameTable(
                name: "AL_DEPARTAMENTO",
                newName: "Alm_Departamento");

            migrationBuilder.RenameTable(
                name: "AL_CATEGORIA",
                newName: "Alm_Categoria");

            migrationBuilder.RenameTable(
                name: "AL_ARTICULO_DETALLE_IMPUESTOS",
                newName: "Alm_ArticuloDetalleImpuestos");

            migrationBuilder.RenameTable(
                name: "AL_ARTICULO",
                newName: "Alm_Articulo");

            migrationBuilder.RenameTable(
                name: "AD_USUARIOEMPRESAS",
                newName: "Admin_UsuarioEmpresas");

            migrationBuilder.RenameTable(
                name: "AD_USUARIOCENTROTRABAJO",
                newName: "Admin_UsuarioCentroTrabajo");

            migrationBuilder.RenameTable(
                name: "AD_TFDsGLOBAL",
                newName: "Admin_TFDsGlobal");

            migrationBuilder.RenameTable(
                name: "AD_TFDsDETALLE",
                newName: "Admin_TFDsDetalle");

            migrationBuilder.RenameTable(
                name: "AD_SUBMENU",
                newName: "Admin_SubMenu");

            migrationBuilder.RenameTable(
                name: "AD_PERMISO",
                newName: "Admin_Permiso");

            migrationBuilder.RenameTable(
                name: "AD_PERFIL",
                newName: "Admin_Perfil");

            migrationBuilder.RenameTable(
                name: "AD_MODULO",
                newName: "Admin_Modulo");

            migrationBuilder.RenameTable(
                name: "AD_MENU",
                newName: "Admin_Menu");

            migrationBuilder.RenameTable(
                name: "AD_EMPRESA",
                newName: "Admin_Empresa");

            migrationBuilder.RenameTable(
                name: "AD_COORPORATIVO",
                newName: "Admin_Coorporativo");

            migrationBuilder.RenameTable(
                name: "AD_CENTROTRABAJO",
                newName: "Admin_CentroTrabajo");

            migrationBuilder.RenameTable(
                name: "AD_ASIGNACIONTFD",
                newName: "Admin_AsignacionTFD");

            migrationBuilder.RenameIndex(
                name: "IX_CL_CLIENTES_E_CoorporativoId",
                table: "Cli_Clientes",
                newName: "IX_Cli_Clientes_E_CoorporativoId");

            migrationBuilder.RenameIndex(
                name: "IX_AL_PROVEEDOR_E_CorporativoId",
                table: "Cli_Proveedor",
                newName: "IX_Cli_Proveedor_E_CorporativoId");

            migrationBuilder.RenameIndex(
                name: "IX_AL_MARCA_E_CorporativoId",
                table: "Cli_Marca",
                newName: "IX_Cli_Marca_E_CorporativoId");

            migrationBuilder.RenameIndex(
                name: "IX_AL_INVENTARIO_DETALLE_PRECIOS_E_InventarioId",
                table: "Alm_InventarioDetallePrecios",
                newName: "IX_Alm_InventarioDetallePrecios_E_InventarioId");

            migrationBuilder.RenameIndex(
                name: "IX_AL_INVENTARIO_E_CentroTrabajoId",
                table: "Alm_Inventario",
                newName: "IX_Alm_Inventario_E_CentroTrabajoId");

            migrationBuilder.RenameIndex(
                name: "IX_AL_DEPARTAMENTO_E_CorporativoId",
                table: "Alm_Departamento",
                newName: "IX_Alm_Departamento_E_CorporativoId");

            migrationBuilder.RenameIndex(
                name: "IX_AL_CATEGORIA_E_DepartamentoId",
                table: "Alm_Categoria",
                newName: "IX_Alm_Categoria_E_DepartamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_AL_ARTICULO_DETALLE_IMPUESTOS_E_ArticuloId",
                table: "Alm_ArticuloDetalleImpuestos",
                newName: "IX_Alm_ArticuloDetalleImpuestos_E_ArticuloId");

            migrationBuilder.RenameIndex(
                name: "IX_AL_ARTICULO_E_ProductoServicioId",
                table: "Alm_Articulo",
                newName: "IX_Alm_Articulo_E_ProductoServicioId");

            migrationBuilder.RenameIndex(
                name: "IX_AL_ARTICULO_E_CategoriaId",
                table: "Alm_Articulo",
                newName: "IX_Alm_Articulo_E_CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_AD_USUARIOEMPRESAS_UserId",
                table: "Admin_UsuarioEmpresas",
                newName: "IX_Admin_UsuarioEmpresas_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AD_USUARIOEMPRESAS_E_EmpresaId",
                table: "Admin_UsuarioEmpresas",
                newName: "IX_Admin_UsuarioEmpresas_E_EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_AD_USUARIOCENTROTRABAJO_UserId",
                table: "Admin_UsuarioCentroTrabajo",
                newName: "IX_Admin_UsuarioCentroTrabajo_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AD_USUARIOCENTROTRABAJO_E_CentroTrabajoId",
                table: "Admin_UsuarioCentroTrabajo",
                newName: "IX_Admin_UsuarioCentroTrabajo_E_CentroTrabajoId");

            migrationBuilder.RenameIndex(
                name: "IX_AD_TFDsDETALLE_E_TFDsGlobalId",
                table: "Admin_TFDsDetalle",
                newName: "IX_Admin_TFDsDetalle_E_TFDsGlobalId");

            migrationBuilder.RenameIndex(
                name: "IX_AD_SUBMENU_MenuId",
                table: "Admin_SubMenu",
                newName: "IX_Admin_SubMenu_MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_AD_PERMISO_E_ModuloId",
                table: "Admin_Permiso",
                newName: "IX_Admin_Permiso_E_ModuloId");

            migrationBuilder.RenameIndex(
                name: "IX_AD_PERMISO_ClaimId",
                table: "Admin_Permiso",
                newName: "IX_Admin_Permiso_ClaimId");

            migrationBuilder.RenameIndex(
                name: "IX_AD_MODULO_RolId",
                table: "Admin_Modulo",
                newName: "IX_Admin_Modulo_RolId");

            migrationBuilder.RenameIndex(
                name: "IX_AD_MODULO_E_PerfilId",
                table: "Admin_Modulo",
                newName: "IX_Admin_Modulo_E_PerfilId");

            migrationBuilder.RenameIndex(
                name: "IX_AD_EMPRESA_E_RegimenFiscalId",
                table: "Admin_Empresa",
                newName: "IX_Admin_Empresa_E_RegimenFiscalId");

            migrationBuilder.RenameIndex(
                name: "IX_AD_EMPRESA_E_CoorporativoId",
                table: "Admin_Empresa",
                newName: "IX_Admin_Empresa_E_CoorporativoId");

            migrationBuilder.RenameIndex(
                name: "IX_AD_CENTROTRABAJO_E_EmpresaId",
                table: "Admin_CentroTrabajo",
                newName: "IX_Admin_CentroTrabajo_E_EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_AD_ASIGNACIONTFD_E_EmpresaId",
                table: "Admin_AsignacionTFD",
                newName: "IX_Admin_AsignacionTFD_E_EmpresaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conf_UsoCFDI",
                table: "Conf_UsoCFDI",
                column: "IdUsoCFDI");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conf_UnidadMedida",
                table: "Conf_UnidadMedida",
                column: "IdUnidadMedida");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conf_TipoRelacion",
                table: "Conf_TipoRelacion",
                column: "IdTipoRelacion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conf_TipoFactor",
                table: "Conf_TipoFactor",
                column: "IdTipoFactor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conf_TipoComprobante",
                table: "Conf_TipoComprobante",
                column: "IdTipoComprobante");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conf_RegimenFiscal",
                table: "Conf_RegimenFiscal",
                column: "IdRegimenFiscal");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conf_ProductoServicio",
                table: "Conf_ProductoServicio",
                column: "IdProductoServicio");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conf_ObjetoImpuesto",
                table: "Conf_ObjetoImpuesto",
                column: "IdObjetoImpuesto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conf_Moneda",
                table: "Conf_Moneda",
                column: "IdMoneda");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conf_MetodoPago",
                table: "Conf_MetodoPago",
                column: "IdMetodoPago");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conf_Impuesto",
                table: "Conf_Impuesto",
                column: "IdImpuesto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conf_FormaPago",
                table: "Conf_FormaPago",
                column: "IdFormaPago");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cli_Clientes",
                table: "Cli_Clientes",
                column: "IdCliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cli_Proveedor",
                table: "Cli_Proveedor",
                column: "IdProveedor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cli_Marca",
                table: "Cli_Marca",
                column: "IdMarca");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alm_InventarioDetallePrecios",
                table: "Alm_InventarioDetallePrecios",
                column: "IdInventarioDetallePrecios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alm_Inventario",
                table: "Alm_Inventario",
                column: "IdInventario");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin_UsuarioEmpresas",
                table: "Admin_UsuarioEmpresas",
                column: "IdUsuarioEmpresa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin_UsuarioCentroTrabajo",
                table: "Admin_UsuarioCentroTrabajo",
                column: "IdUsuarioCentroTrabajo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin_TFDsGlobal",
                table: "Admin_TFDsGlobal",
                column: "IdTFDsGlobal");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin_TFDsDetalle",
                table: "Admin_TFDsDetalle",
                column: "IdDetalleTFD");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin_SubMenu",
                table: "Admin_SubMenu",
                column: "IdSubMenu");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin_Permiso",
                table: "Admin_Permiso",
                column: "IdPermiso");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin_Perfil",
                table: "Admin_Perfil",
                column: "IdPerfil");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin_Modulo",
                table: "Admin_Modulo",
                column: "IdModulo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin_Menu",
                table: "Admin_Menu",
                column: "IdMenu");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin_Empresa",
                table: "Admin_Empresa",
                column: "IdEmpresa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin_Coorporativo",
                table: "Admin_Coorporativo",
                column: "IdCoorporativo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin_CentroTrabajo",
                table: "Admin_CentroTrabajo",
                column: "IdCentroTrabajo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin_AsignacionTFD",
                table: "Admin_AsignacionTFD",
                column: "IdAsignacionTFDs");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_AsignacionTFD_Admin_Empresa_E_EmpresaId",
                table: "Admin_AsignacionTFD",
                column: "E_EmpresaId",
                principalTable: "Admin_Empresa",
                principalColumn: "IdEmpresa",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_CentroTrabajo_Admin_Empresa_E_EmpresaId",
                table: "Admin_CentroTrabajo",
                column: "E_EmpresaId",
                principalTable: "Admin_Empresa",
                principalColumn: "IdEmpresa",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_Empresa_Admin_Coorporativo_E_CoorporativoId",
                table: "Admin_Empresa",
                column: "E_CoorporativoId",
                principalTable: "Admin_Coorporativo",
                principalColumn: "IdCoorporativo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_Empresa_Conf_RegimenFiscal_E_RegimenFiscalId",
                table: "Admin_Empresa",
                column: "E_RegimenFiscalId",
                principalTable: "Conf_RegimenFiscal",
                principalColumn: "IdRegimenFiscal",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_Modulo_Admin_Perfil_E_PerfilId",
                table: "Admin_Modulo",
                column: "E_PerfilId",
                principalTable: "Admin_Perfil",
                principalColumn: "IdPerfil",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_Modulo_AspNetRoles_RolId",
                table: "Admin_Modulo",
                column: "RolId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_Permiso_Admin_Modulo_E_ModuloId",
                table: "Admin_Permiso",
                column: "E_ModuloId",
                principalTable: "Admin_Modulo",
                principalColumn: "IdModulo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_Permiso_AspNetRoleClaims_ClaimId",
                table: "Admin_Permiso",
                column: "ClaimId",
                principalTable: "AspNetRoleClaims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_SubMenu_Admin_Menu_MenuId",
                table: "Admin_SubMenu",
                column: "MenuId",
                principalTable: "Admin_Menu",
                principalColumn: "IdMenu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_TFDsDetalle_Admin_TFDsGlobal_E_TFDsGlobalId",
                table: "Admin_TFDsDetalle",
                column: "E_TFDsGlobalId",
                principalTable: "Admin_TFDsGlobal",
                principalColumn: "IdTFDsGlobal",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_UsuarioCentroTrabajo_Admin_CentroTrabajo_E_CentroTrabajoId",
                table: "Admin_UsuarioCentroTrabajo",
                column: "E_CentroTrabajoId",
                principalTable: "Admin_CentroTrabajo",
                principalColumn: "IdCentroTrabajo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_UsuarioCentroTrabajo_AspNetUsers_UserId",
                table: "Admin_UsuarioCentroTrabajo",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_UsuarioEmpresas_Admin_Empresa_E_EmpresaId",
                table: "Admin_UsuarioEmpresas",
                column: "E_EmpresaId",
                principalTable: "Admin_Empresa",
                principalColumn: "IdEmpresa",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_UsuarioEmpresas_AspNetUsers_UserId",
                table: "Admin_UsuarioEmpresas",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

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
                name: "FK_Alm_Inventario_Admin_CentroTrabajo_E_CentroTrabajoId",
                table: "Alm_Inventario",
                column: "E_CentroTrabajoId",
                principalTable: "Admin_CentroTrabajo",
                principalColumn: "IdCentroTrabajo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alm_InventarioDetallePrecios_Alm_Inventario_E_InventarioId",
                table: "Alm_InventarioDetallePrecios",
                column: "E_InventarioId",
                principalTable: "Alm_Inventario",
                principalColumn: "IdInventario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Admin_CentroTrabajo_E_CentroTrabajoId",
                table: "AspNetUsers",
                column: "E_CentroTrabajoId",
                principalTable: "Admin_CentroTrabajo",
                principalColumn: "IdCentroTrabajo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cli_Clientes_Admin_Coorporativo_E_CoorporativoId",
                table: "Cli_Clientes",
                column: "E_CoorporativoId",
                principalTable: "Admin_Coorporativo",
                principalColumn: "IdCoorporativo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cli_Marca_Admin_Coorporativo_E_CorporativoId",
                table: "Cli_Marca",
                column: "E_CorporativoId",
                principalTable: "Admin_Coorporativo",
                principalColumn: "IdCoorporativo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cli_Proveedor_Admin_Coorporativo_E_CorporativoId",
                table: "Cli_Proveedor",
                column: "E_CorporativoId",
                principalTable: "Admin_Coorporativo",
                principalColumn: "IdCoorporativo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_AsignacionTFD_Admin_Empresa_E_EmpresaId",
                table: "Admin_AsignacionTFD");

            migrationBuilder.DropForeignKey(
                name: "FK_Admin_CentroTrabajo_Admin_Empresa_E_EmpresaId",
                table: "Admin_CentroTrabajo");

            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Empresa_Admin_Coorporativo_E_CoorporativoId",
                table: "Admin_Empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Empresa_Conf_RegimenFiscal_E_RegimenFiscalId",
                table: "Admin_Empresa");

            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Modulo_Admin_Perfil_E_PerfilId",
                table: "Admin_Modulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Modulo_AspNetRoles_RolId",
                table: "Admin_Modulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Permiso_Admin_Modulo_E_ModuloId",
                table: "Admin_Permiso");

            migrationBuilder.DropForeignKey(
                name: "FK_Admin_Permiso_AspNetRoleClaims_ClaimId",
                table: "Admin_Permiso");

            migrationBuilder.DropForeignKey(
                name: "FK_Admin_SubMenu_Admin_Menu_MenuId",
                table: "Admin_SubMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_Admin_TFDsDetalle_Admin_TFDsGlobal_E_TFDsGlobalId",
                table: "Admin_TFDsDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_Admin_UsuarioCentroTrabajo_Admin_CentroTrabajo_E_CentroTrabajoId",
                table: "Admin_UsuarioCentroTrabajo");

            migrationBuilder.DropForeignKey(
                name: "FK_Admin_UsuarioCentroTrabajo_AspNetUsers_UserId",
                table: "Admin_UsuarioCentroTrabajo");

            migrationBuilder.DropForeignKey(
                name: "FK_Admin_UsuarioEmpresas_Admin_Empresa_E_EmpresaId",
                table: "Admin_UsuarioEmpresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Admin_UsuarioEmpresas_AspNetUsers_UserId",
                table: "Admin_UsuarioEmpresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Alm_Articulo_Alm_Categoria_E_CategoriaId",
                table: "Alm_Articulo");

            migrationBuilder.DropForeignKey(
                name: "FK_Alm_Articulo_Conf_ProductoServicio_E_ProductoServicioId",
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
                name: "FK_Alm_Inventario_Admin_CentroTrabajo_E_CentroTrabajoId",
                table: "Alm_Inventario");

            migrationBuilder.DropForeignKey(
                name: "FK_Alm_InventarioDetallePrecios_Alm_Inventario_E_InventarioId",
                table: "Alm_InventarioDetallePrecios");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Admin_CentroTrabajo_E_CentroTrabajoId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Cli_Clientes_Admin_Coorporativo_E_CoorporativoId",
                table: "Cli_Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Cli_Marca_Admin_Coorporativo_E_CorporativoId",
                table: "Cli_Marca");

            migrationBuilder.DropForeignKey(
                name: "FK_Cli_Proveedor_Admin_Coorporativo_E_CorporativoId",
                table: "Cli_Proveedor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conf_UsoCFDI",
                table: "Conf_UsoCFDI");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conf_UnidadMedida",
                table: "Conf_UnidadMedida");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conf_TipoRelacion",
                table: "Conf_TipoRelacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conf_TipoFactor",
                table: "Conf_TipoFactor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conf_TipoComprobante",
                table: "Conf_TipoComprobante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conf_RegimenFiscal",
                table: "Conf_RegimenFiscal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conf_ProductoServicio",
                table: "Conf_ProductoServicio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conf_ObjetoImpuesto",
                table: "Conf_ObjetoImpuesto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conf_Moneda",
                table: "Conf_Moneda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conf_MetodoPago",
                table: "Conf_MetodoPago");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conf_Impuesto",
                table: "Conf_Impuesto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conf_FormaPago",
                table: "Conf_FormaPago");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cli_Proveedor",
                table: "Cli_Proveedor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cli_Marca",
                table: "Cli_Marca");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cli_Clientes",
                table: "Cli_Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alm_InventarioDetallePrecios",
                table: "Alm_InventarioDetallePrecios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alm_Inventario",
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin_UsuarioEmpresas",
                table: "Admin_UsuarioEmpresas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin_UsuarioCentroTrabajo",
                table: "Admin_UsuarioCentroTrabajo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin_TFDsGlobal",
                table: "Admin_TFDsGlobal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin_TFDsDetalle",
                table: "Admin_TFDsDetalle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin_SubMenu",
                table: "Admin_SubMenu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin_Permiso",
                table: "Admin_Permiso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin_Perfil",
                table: "Admin_Perfil");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin_Modulo",
                table: "Admin_Modulo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin_Menu",
                table: "Admin_Menu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin_Empresa",
                table: "Admin_Empresa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin_Coorporativo",
                table: "Admin_Coorporativo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin_CentroTrabajo",
                table: "Admin_CentroTrabajo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin_AsignacionTFD",
                table: "Admin_AsignacionTFD");

            migrationBuilder.RenameTable(
                name: "Conf_UsoCFDI",
                newName: "CO_USOCFDI");

            migrationBuilder.RenameTable(
                name: "Conf_UnidadMedida",
                newName: "CO_UNIDADMEDIDA");

            migrationBuilder.RenameTable(
                name: "Conf_TipoRelacion",
                newName: "CO_TIPORELACION");

            migrationBuilder.RenameTable(
                name: "Conf_TipoFactor",
                newName: "CO_TIPOFACTOR");

            migrationBuilder.RenameTable(
                name: "Conf_TipoComprobante",
                newName: "CO_TIPOCOMPROBANTE");

            migrationBuilder.RenameTable(
                name: "Conf_RegimenFiscal",
                newName: "CO_REGIMENFISCAL");

            migrationBuilder.RenameTable(
                name: "Conf_ProductoServicio",
                newName: "CO_PRODUCTOSERVICIO");

            migrationBuilder.RenameTable(
                name: "Conf_ObjetoImpuesto",
                newName: "CO_OBJETOIMPUESTO");

            migrationBuilder.RenameTable(
                name: "Conf_Moneda",
                newName: "CO_MONEDA");

            migrationBuilder.RenameTable(
                name: "Conf_MetodoPago",
                newName: "CO_METODOPAGO");

            migrationBuilder.RenameTable(
                name: "Conf_Impuesto",
                newName: "CO_IMPUESTO");

            migrationBuilder.RenameTable(
                name: "Conf_FormaPago",
                newName: "CO_FORMAPAGO");

            migrationBuilder.RenameTable(
                name: "Cli_Proveedor",
                newName: "AL_PROVEEDOR");

            migrationBuilder.RenameTable(
                name: "Cli_Marca",
                newName: "AL_MARCA");

            migrationBuilder.RenameTable(
                name: "Cli_Clientes",
                newName: "CL_CLIENTES");

            migrationBuilder.RenameTable(
                name: "Alm_InventarioDetallePrecios",
                newName: "AL_INVENTARIO_DETALLE_PRECIOS");

            migrationBuilder.RenameTable(
                name: "Alm_Inventario",
                newName: "AL_INVENTARIO");

            migrationBuilder.RenameTable(
                name: "Alm_Departamento",
                newName: "AL_DEPARTAMENTO");

            migrationBuilder.RenameTable(
                name: "Alm_Categoria",
                newName: "AL_CATEGORIA");

            migrationBuilder.RenameTable(
                name: "Alm_ArticuloDetalleImpuestos",
                newName: "AL_ARTICULO_DETALLE_IMPUESTOS");

            migrationBuilder.RenameTable(
                name: "Alm_Articulo",
                newName: "AL_ARTICULO");

            migrationBuilder.RenameTable(
                name: "Admin_UsuarioEmpresas",
                newName: "AD_USUARIOEMPRESAS");

            migrationBuilder.RenameTable(
                name: "Admin_UsuarioCentroTrabajo",
                newName: "AD_USUARIOCENTROTRABAJO");

            migrationBuilder.RenameTable(
                name: "Admin_TFDsGlobal",
                newName: "AD_TFDsGLOBAL");

            migrationBuilder.RenameTable(
                name: "Admin_TFDsDetalle",
                newName: "AD_TFDsDETALLE");

            migrationBuilder.RenameTable(
                name: "Admin_SubMenu",
                newName: "AD_SUBMENU");

            migrationBuilder.RenameTable(
                name: "Admin_Permiso",
                newName: "AD_PERMISO");

            migrationBuilder.RenameTable(
                name: "Admin_Perfil",
                newName: "AD_PERFIL");

            migrationBuilder.RenameTable(
                name: "Admin_Modulo",
                newName: "AD_MODULO");

            migrationBuilder.RenameTable(
                name: "Admin_Menu",
                newName: "AD_MENU");

            migrationBuilder.RenameTable(
                name: "Admin_Empresa",
                newName: "AD_EMPRESA");

            migrationBuilder.RenameTable(
                name: "Admin_Coorporativo",
                newName: "AD_COORPORATIVO");

            migrationBuilder.RenameTable(
                name: "Admin_CentroTrabajo",
                newName: "AD_CENTROTRABAJO");

            migrationBuilder.RenameTable(
                name: "Admin_AsignacionTFD",
                newName: "AD_ASIGNACIONTFD");

            migrationBuilder.RenameIndex(
                name: "IX_Cli_Proveedor_E_CorporativoId",
                table: "AL_PROVEEDOR",
                newName: "IX_AL_PROVEEDOR_E_CorporativoId");

            migrationBuilder.RenameIndex(
                name: "IX_Cli_Marca_E_CorporativoId",
                table: "AL_MARCA",
                newName: "IX_AL_MARCA_E_CorporativoId");

            migrationBuilder.RenameIndex(
                name: "IX_Cli_Clientes_E_CoorporativoId",
                table: "CL_CLIENTES",
                newName: "IX_CL_CLIENTES_E_CoorporativoId");

            migrationBuilder.RenameIndex(
                name: "IX_Alm_InventarioDetallePrecios_E_InventarioId",
                table: "AL_INVENTARIO_DETALLE_PRECIOS",
                newName: "IX_AL_INVENTARIO_DETALLE_PRECIOS_E_InventarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Alm_Inventario_E_CentroTrabajoId",
                table: "AL_INVENTARIO",
                newName: "IX_AL_INVENTARIO_E_CentroTrabajoId");

            migrationBuilder.RenameIndex(
                name: "IX_Alm_Departamento_E_CorporativoId",
                table: "AL_DEPARTAMENTO",
                newName: "IX_AL_DEPARTAMENTO_E_CorporativoId");

            migrationBuilder.RenameIndex(
                name: "IX_Alm_Categoria_E_DepartamentoId",
                table: "AL_CATEGORIA",
                newName: "IX_AL_CATEGORIA_E_DepartamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Alm_ArticuloDetalleImpuestos_E_ArticuloId",
                table: "AL_ARTICULO_DETALLE_IMPUESTOS",
                newName: "IX_AL_ARTICULO_DETALLE_IMPUESTOS_E_ArticuloId");

            migrationBuilder.RenameIndex(
                name: "IX_Alm_Articulo_E_ProductoServicioId",
                table: "AL_ARTICULO",
                newName: "IX_AL_ARTICULO_E_ProductoServicioId");

            migrationBuilder.RenameIndex(
                name: "IX_Alm_Articulo_E_CategoriaId",
                table: "AL_ARTICULO",
                newName: "IX_AL_ARTICULO_E_CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_Admin_UsuarioEmpresas_UserId",
                table: "AD_USUARIOEMPRESAS",
                newName: "IX_AD_USUARIOEMPRESAS_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Admin_UsuarioEmpresas_E_EmpresaId",
                table: "AD_USUARIOEMPRESAS",
                newName: "IX_AD_USUARIOEMPRESAS_E_EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_Admin_UsuarioCentroTrabajo_UserId",
                table: "AD_USUARIOCENTROTRABAJO",
                newName: "IX_AD_USUARIOCENTROTRABAJO_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Admin_UsuarioCentroTrabajo_E_CentroTrabajoId",
                table: "AD_USUARIOCENTROTRABAJO",
                newName: "IX_AD_USUARIOCENTROTRABAJO_E_CentroTrabajoId");

            migrationBuilder.RenameIndex(
                name: "IX_Admin_TFDsDetalle_E_TFDsGlobalId",
                table: "AD_TFDsDETALLE",
                newName: "IX_AD_TFDsDETALLE_E_TFDsGlobalId");

            migrationBuilder.RenameIndex(
                name: "IX_Admin_SubMenu_MenuId",
                table: "AD_SUBMENU",
                newName: "IX_AD_SUBMENU_MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Admin_Permiso_E_ModuloId",
                table: "AD_PERMISO",
                newName: "IX_AD_PERMISO_E_ModuloId");

            migrationBuilder.RenameIndex(
                name: "IX_Admin_Permiso_ClaimId",
                table: "AD_PERMISO",
                newName: "IX_AD_PERMISO_ClaimId");

            migrationBuilder.RenameIndex(
                name: "IX_Admin_Modulo_RolId",
                table: "AD_MODULO",
                newName: "IX_AD_MODULO_RolId");

            migrationBuilder.RenameIndex(
                name: "IX_Admin_Modulo_E_PerfilId",
                table: "AD_MODULO",
                newName: "IX_AD_MODULO_E_PerfilId");

            migrationBuilder.RenameIndex(
                name: "IX_Admin_Empresa_E_RegimenFiscalId",
                table: "AD_EMPRESA",
                newName: "IX_AD_EMPRESA_E_RegimenFiscalId");

            migrationBuilder.RenameIndex(
                name: "IX_Admin_Empresa_E_CoorporativoId",
                table: "AD_EMPRESA",
                newName: "IX_AD_EMPRESA_E_CoorporativoId");

            migrationBuilder.RenameIndex(
                name: "IX_Admin_CentroTrabajo_E_EmpresaId",
                table: "AD_CENTROTRABAJO",
                newName: "IX_AD_CENTROTRABAJO_E_EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_Admin_AsignacionTFD_E_EmpresaId",
                table: "AD_ASIGNACIONTFD",
                newName: "IX_AD_ASIGNACIONTFD_E_EmpresaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CO_USOCFDI",
                table: "CO_USOCFDI",
                column: "IdUsoCFDI");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CO_UNIDADMEDIDA",
                table: "CO_UNIDADMEDIDA",
                column: "IdUnidadMedida");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CO_TIPORELACION",
                table: "CO_TIPORELACION",
                column: "IdTipoRelacion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CO_TIPOFACTOR",
                table: "CO_TIPOFACTOR",
                column: "IdTipoFactor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CO_TIPOCOMPROBANTE",
                table: "CO_TIPOCOMPROBANTE",
                column: "IdTipoComprobante");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CO_REGIMENFISCAL",
                table: "CO_REGIMENFISCAL",
                column: "IdRegimenFiscal");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CO_PRODUCTOSERVICIO",
                table: "CO_PRODUCTOSERVICIO",
                column: "IdProductoServicio");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CO_OBJETOIMPUESTO",
                table: "CO_OBJETOIMPUESTO",
                column: "IdObjetoImpuesto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CO_MONEDA",
                table: "CO_MONEDA",
                column: "IdMoneda");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CO_METODOPAGO",
                table: "CO_METODOPAGO",
                column: "IdMetodoPago");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CO_IMPUESTO",
                table: "CO_IMPUESTO",
                column: "IdImpuesto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CO_FORMAPAGO",
                table: "CO_FORMAPAGO",
                column: "IdFormaPago");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AL_PROVEEDOR",
                table: "AL_PROVEEDOR",
                column: "IdProveedor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AL_MARCA",
                table: "AL_MARCA",
                column: "IdMarca");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CL_CLIENTES",
                table: "CL_CLIENTES",
                column: "IdCliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AL_INVENTARIO_DETALLE_PRECIOS",
                table: "AL_INVENTARIO_DETALLE_PRECIOS",
                column: "IdInventarioDetallePrecios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AL_INVENTARIO",
                table: "AL_INVENTARIO",
                column: "IdInventario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AL_DEPARTAMENTO",
                table: "AL_DEPARTAMENTO",
                column: "IdDepartamento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AL_CATEGORIA",
                table: "AL_CATEGORIA",
                column: "IdCategoria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AL_ARTICULO_DETALLE_IMPUESTOS",
                table: "AL_ARTICULO_DETALLE_IMPUESTOS",
                column: "IdArticuloDetalleImpuestos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AL_ARTICULO",
                table: "AL_ARTICULO",
                column: "IdArticulo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AD_USUARIOEMPRESAS",
                table: "AD_USUARIOEMPRESAS",
                column: "IdUsuarioEmpresa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AD_USUARIOCENTROTRABAJO",
                table: "AD_USUARIOCENTROTRABAJO",
                column: "IdUsuarioCentroTrabajo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AD_TFDsGLOBAL",
                table: "AD_TFDsGLOBAL",
                column: "IdTFDsGlobal");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AD_TFDsDETALLE",
                table: "AD_TFDsDETALLE",
                column: "IdDetalleTFD");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AD_SUBMENU",
                table: "AD_SUBMENU",
                column: "IdSubMenu");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AD_PERMISO",
                table: "AD_PERMISO",
                column: "IdPermiso");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AD_PERFIL",
                table: "AD_PERFIL",
                column: "IdPerfil");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AD_MODULO",
                table: "AD_MODULO",
                column: "IdModulo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AD_MENU",
                table: "AD_MENU",
                column: "IdMenu");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AD_EMPRESA",
                table: "AD_EMPRESA",
                column: "IdEmpresa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AD_COORPORATIVO",
                table: "AD_COORPORATIVO",
                column: "IdCoorporativo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AD_CENTROTRABAJO",
                table: "AD_CENTROTRABAJO",
                column: "IdCentroTrabajo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AD_ASIGNACIONTFD",
                table: "AD_ASIGNACIONTFD",
                column: "IdAsignacionTFDs");

            migrationBuilder.AddForeignKey(
                name: "FK_AD_ASIGNACIONTFD_AD_EMPRESA_E_EmpresaId",
                table: "AD_ASIGNACIONTFD",
                column: "E_EmpresaId",
                principalTable: "AD_EMPRESA",
                principalColumn: "IdEmpresa",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AD_CENTROTRABAJO_AD_EMPRESA_E_EmpresaId",
                table: "AD_CENTROTRABAJO",
                column: "E_EmpresaId",
                principalTable: "AD_EMPRESA",
                principalColumn: "IdEmpresa",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AD_EMPRESA_AD_COORPORATIVO_E_CoorporativoId",
                table: "AD_EMPRESA",
                column: "E_CoorporativoId",
                principalTable: "AD_COORPORATIVO",
                principalColumn: "IdCoorporativo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AD_EMPRESA_CO_REGIMENFISCAL_E_RegimenFiscalId",
                table: "AD_EMPRESA",
                column: "E_RegimenFiscalId",
                principalTable: "CO_REGIMENFISCAL",
                principalColumn: "IdRegimenFiscal",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AD_MODULO_AD_PERFIL_E_PerfilId",
                table: "AD_MODULO",
                column: "E_PerfilId",
                principalTable: "AD_PERFIL",
                principalColumn: "IdPerfil",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AD_MODULO_AspNetRoles_RolId",
                table: "AD_MODULO",
                column: "RolId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AD_PERMISO_AD_MODULO_E_ModuloId",
                table: "AD_PERMISO",
                column: "E_ModuloId",
                principalTable: "AD_MODULO",
                principalColumn: "IdModulo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AD_PERMISO_AspNetRoleClaims_ClaimId",
                table: "AD_PERMISO",
                column: "ClaimId",
                principalTable: "AspNetRoleClaims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AD_SUBMENU_AD_MENU_MenuId",
                table: "AD_SUBMENU",
                column: "MenuId",
                principalTable: "AD_MENU",
                principalColumn: "IdMenu",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AD_TFDsDETALLE_AD_TFDsGLOBAL_E_TFDsGlobalId",
                table: "AD_TFDsDETALLE",
                column: "E_TFDsGlobalId",
                principalTable: "AD_TFDsGLOBAL",
                principalColumn: "IdTFDsGlobal",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AD_USUARIOCENTROTRABAJO_AD_CENTROTRABAJO_E_CentroTrabajoId",
                table: "AD_USUARIOCENTROTRABAJO",
                column: "E_CentroTrabajoId",
                principalTable: "AD_CENTROTRABAJO",
                principalColumn: "IdCentroTrabajo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AD_USUARIOCENTROTRABAJO_AspNetUsers_UserId",
                table: "AD_USUARIOCENTROTRABAJO",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AD_USUARIOEMPRESAS_AD_EMPRESA_E_EmpresaId",
                table: "AD_USUARIOEMPRESAS",
                column: "E_EmpresaId",
                principalTable: "AD_EMPRESA",
                principalColumn: "IdEmpresa",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AD_USUARIOEMPRESAS_AspNetUsers_UserId",
                table: "AD_USUARIOEMPRESAS",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AL_ARTICULO_AL_CATEGORIA_E_CategoriaId",
                table: "AL_ARTICULO",
                column: "E_CategoriaId",
                principalTable: "AL_CATEGORIA",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AL_ARTICULO_CO_PRODUCTOSERVICIO_E_ProductoServicioId",
                table: "AL_ARTICULO",
                column: "E_ProductoServicioId",
                principalTable: "CO_PRODUCTOSERVICIO",
                principalColumn: "IdProductoServicio",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AL_ARTICULO_DETALLE_IMPUESTOS_AL_ARTICULO_E_ArticuloId",
                table: "AL_ARTICULO_DETALLE_IMPUESTOS",
                column: "E_ArticuloId",
                principalTable: "AL_ARTICULO",
                principalColumn: "IdArticulo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AL_CATEGORIA_AL_DEPARTAMENTO_E_DepartamentoId",
                table: "AL_CATEGORIA",
                column: "E_DepartamentoId",
                principalTable: "AL_DEPARTAMENTO",
                principalColumn: "IdDepartamento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AL_DEPARTAMENTO_AD_COORPORATIVO_E_CorporativoId",
                table: "AL_DEPARTAMENTO",
                column: "E_CorporativoId",
                principalTable: "AD_COORPORATIVO",
                principalColumn: "IdCoorporativo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AL_INVENTARIO_AD_CENTROTRABAJO_E_CentroTrabajoId",
                table: "AL_INVENTARIO",
                column: "E_CentroTrabajoId",
                principalTable: "AD_CENTROTRABAJO",
                principalColumn: "IdCentroTrabajo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AL_INVENTARIO_DETALLE_PRECIOS_AL_INVENTARIO_E_InventarioId",
                table: "AL_INVENTARIO_DETALLE_PRECIOS",
                column: "E_InventarioId",
                principalTable: "AL_INVENTARIO",
                principalColumn: "IdInventario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AL_MARCA_AD_COORPORATIVO_E_CorporativoId",
                table: "AL_MARCA",
                column: "E_CorporativoId",
                principalTable: "AD_COORPORATIVO",
                principalColumn: "IdCoorporativo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AL_PROVEEDOR_AD_COORPORATIVO_E_CorporativoId",
                table: "AL_PROVEEDOR",
                column: "E_CorporativoId",
                principalTable: "AD_COORPORATIVO",
                principalColumn: "IdCoorporativo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AD_CENTROTRABAJO_E_CentroTrabajoId",
                table: "AspNetUsers",
                column: "E_CentroTrabajoId",
                principalTable: "AD_CENTROTRABAJO",
                principalColumn: "IdCentroTrabajo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CL_CLIENTES_AD_COORPORATIVO_E_CoorporativoId",
                table: "CL_CLIENTES",
                column: "E_CoorporativoId",
                principalTable: "AD_COORPORATIVO",
                principalColumn: "IdCoorporativo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
