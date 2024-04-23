
using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using sw.Datos.Administracion.Coorporativo;
using sw.Datos.Administracion.Empresa;
using sw.Datos.Administracion.CentroTrabajo;
using sw.Datos.Administracion.Menus;
using sw.Datos.Administracion.PerfilesPer;
using sw.Datos.Administracion.UsuarioEmpresas;
using sw.Datos.Administracion.UsuarioCentroTrabajoes;
using sw.Datos.Administracion.TFDs;

using sw.Datos.Configuracion.CatalogoSAT;
using sw.Datos.Configuracion.Almacen;

using sw.Datos.Clientes;

using sw.Datos.Almacen.Categoria;
using sw.Datos.Almacen.Departamento;
using sw.Datos.Almacen.Articulo;
using sw.Datos.Almacen.Inventario;




using sw.Entidades.Identity;
using sw.Entidades.Administracion.Coorporativo;
using sw.Entidades.Administracion.Empresa;
using sw.Entidades.Administracion.CentroTrabajo;
using sw.Entidades.Administracion.Menus;
using sw.Entidades.Administracion.UsuarioEmpresas;
using sw.Entidades.Administracion.UsuarioCentroTrabajoes;
using sw.Entidades.Administracion.TFDs;
using sw.Entidades.Administracion.PerfilesPer;

using sw.Entidades.Configuracion.CatalogoSAT;
using sw.Entidades.Configuracion.Almacen;

using sw.Entidades.Clientes;

using sw.Entidades.Almacen.Categoria;
using sw.Entidades.Almacen.Departamento;
using sw.Entidades.Almacen.Articulo;
using sw.Entidades.Almacen.Inventario;



namespace sw.Datos
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRol, string, ApplicationUserClaim, ApplicationUserRole, IdentityUserLogin<string>, ApplicationRoleClaim, IdentityUserToken<string>>
    {


        //MODULO ADMINISTRACION
        public DbSet<E_Coorporativo> E_Coorporativos { get; set; }
        public DbSet<E_Empresa> E_Empresas { get; set; }
        public DbSet<E_CentroTrabajo> E_CentroTrabajos { get; set; }
        public DbSet<E_UsuarioEmpresas> E_UsuarioEmpresas { get; set; }
        public DbSet<E_UsuarioCentroTrabajoes> E_UsuarioCentroTrabajo { get; set; }

        public DbSet<E_Menu> E_Menus { get; set; }
        public DbSet<E_SubMenu> E_SubMenus { get; set; }

        public DbSet<E_Perfil> E_Perfil { get; set; }
        public DbSet<E_Modulo> E_Modulo { get; set; }
        public DbSet<E_Permiso> E_Permiso { get; set; }
        public DbSet<E_TFDsGlobal> E_TFDsGlobals { get; set; }
        public DbSet<E_TFDsDetalle> E_TFDsDetalles { get; set; }
        public DbSet<E_AsignacionTFD> E_AsignacionTFDs { get; set; }



        //MODULO CONFIGURACION_CATALOGOSAT
        public DbSet<E_Prueba> E_Pruebas { get; set; }
        public DbSet<E_FormaPago> E_FormaPago { get; set; }
        public DbSet<E_Impuesto> E_Impuesto { get; set; }
        public DbSet<E_Moneda> E_Moneda { get; set; }
        public DbSet<E_ProductoServicio> E_ProductoServicios { get; set; }
        public DbSet<E_RegimenFiscal> E_RegimenFiscals { get; set; }
        public DbSet<E_TipoComprobante> E_TipoComprobante { get; set; }
        public DbSet<E_TipoRelacion> E_TipoRelacions { get; set; }
        public DbSet<E_UnidadMedida> E_UnidadMedidas { get; set; }
        public DbSet<E_UsoCFDI> E_UsoCFDIs { get; set; }
        public DbSet<E_MetodoPago> E_MetodoPagos { get; set; }
        public DbSet<E_ObjetoImpuesto> E_ObjetoImpuestos { get; set; }
        public DbSet<E_TipoFactor> E_TipoFactors { get; set; }

        //MODULO CONFIGURACION_ALMACEN
        public DbSet<E_Marca> E_Marcas { get; set; }
        public DbSet<E_Proveedor> E_Proveedor { get; set; }

        //MODULO CLIENTE
        public DbSet<E_Clientes> E_Clientes { get; set; }


        //MODULO ALMACEN
        public DbSet<E_Departamento> E_Departamentos { get; set; }
        public DbSet<E_Categoria> E_Categorias { get; set; }
        public DbSet<E_Articulo> E_Articulo { get; set; }
        public DbSet<E_ArticuloDetalleImpuestos> E_ArticuloDetalleImpuestos { get; set; }
        public DbSet<E_Inventario> E_Inventarios { get; set; }
        public DbSet<E_InventarioDetallePrecios> E_InventarioDetallePrecios { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // MODULO DE ADMINISTRACION
            modelBuilder.ApplyConfiguration(new D_Coorporativo());
            modelBuilder.ApplyConfiguration(new D_Empresa());
            modelBuilder.ApplyConfiguration(new D_CentroTrabajo());
            modelBuilder.ApplyConfiguration(new D_UsuarioEmpresas());
            modelBuilder.ApplyConfiguration(new D_UsuarioCentroTrabajoes());

            modelBuilder.ApplyConfiguration(new D_Menu());
            modelBuilder.ApplyConfiguration(new D_SubMenu());

            modelBuilder.ApplyConfiguration(new D_Prefil());
            modelBuilder.ApplyConfiguration(new D_Modulo());
            modelBuilder.ApplyConfiguration(new D_Permiso());

            modelBuilder.ApplyConfiguration(new D_TFDsGlobal());
            modelBuilder.ApplyConfiguration(new D_TFDsDetalle());
            modelBuilder.ApplyConfiguration(new D_AsignacionTFD());

            //MODULO CONFIGURACION_CATALOGOSAT
            modelBuilder.ApplyConfiguration(new D_Prueba());
            modelBuilder.ApplyConfiguration(new D_FormaPago());
            modelBuilder.ApplyConfiguration(new D_Impuesto());
            modelBuilder.ApplyConfiguration(new D_Moneda());
            modelBuilder.ApplyConfiguration(new D_TipoComprobante());
            modelBuilder.ApplyConfiguration(new D_ProductoServicio());
            modelBuilder.ApplyConfiguration(new D_TipoRelacion());
            modelBuilder.ApplyConfiguration(new D_UnidadMedida());
            modelBuilder.ApplyConfiguration(new D_RegimenFiscal());
            modelBuilder.ApplyConfiguration(new D_UsoCFDI());
            modelBuilder.ApplyConfiguration(new D_MetodoPago());
            modelBuilder.ApplyConfiguration(new D_ObjetoImpuesto());
            modelBuilder.ApplyConfiguration(new D_TipoFactor());
            //MODULO CONFIGURACION_ALMACEN
            modelBuilder.ApplyConfiguration(new D_Marca());
            modelBuilder.ApplyConfiguration(new D_Proveedor());
            //MODULO CLIENTE
            modelBuilder.ApplyConfiguration(new D_Clientes());
            //MODULO ALMACEN
            modelBuilder.ApplyConfiguration(new D_Departamento());
            modelBuilder.ApplyConfiguration(new D_Categoria());
            modelBuilder.ApplyConfiguration(new D_Articulo());
            modelBuilder.ApplyConfiguration(new D_ArticulosDetalleImpuestos());
            modelBuilder.ApplyConfiguration(new D_Inventario());
            modelBuilder.ApplyConfiguration(new D_InventarioDetallePrecios());

        }


    }
}