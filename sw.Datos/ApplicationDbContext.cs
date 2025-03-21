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
using sw.Datos.Configuracion.Productos;
using sw.Datos.Configuracion.Gastos;

using sw.Datos.Clientes.Cliente;

using sw.Datos.Productos.Categoria;
using sw.Datos.Productos.Departamento;
using sw.Datos.Productos.Producto;

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
using sw.Entidades.Configuracion.Productos;
using sw.Entidades.Configuracion.Gastos;

using sw.Entidades.Clientes.Cliente;

using sw.Entidades.Productos.Categoria;
using sw.Entidades.Productos.Departamento;
using sw.Entidades.Productos.Producto;

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

        //MODULO CONFIGURACION_PRODUCTO
        public DbSet<E_Marca> E_Marcas { get; set; }
        public DbSet<E_Proveedor> E_Proveedor { get; set; }

        //MODULO GASTOS
        public DbSet<E_Gasto> E_Gastos { get; set; }

        //MODULO CLIENTE
        public DbSet<E_Clientes> E_Clientes { get; set; }


        //MODULO PRODUCTOS
        public DbSet<E_Departamento> E_Departamentos { get; set; }
        public DbSet<E_Categoria> E_Categorias { get; set; }
        public DbSet<E_Producto> E_Producto { get; set; }
        public DbSet<E_ProductoDetalleImpuestos> E_ProductoDetalleImpuestos { get; set; }
        public DbSet<E_ProductoDetallePrecios> E_ProductoDetallePrecios { get; set; }


        // MODULO INVENTARIO
        public DbSet<E_Inventario> E_Inventarios { get; set; }

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
            //MODULO GASTOS
            modelBuilder.ApplyConfiguration(new D_Gasto());
            //MODULO CLIENTE
            modelBuilder.ApplyConfiguration(new D_Clientes());
            //MODULO PRODUCTO
            modelBuilder.ApplyConfiguration(new D_Departamento());
            modelBuilder.ApplyConfiguration(new D_Categoria());
            modelBuilder.ApplyConfiguration(new D_Producto());
            modelBuilder.ApplyConfiguration(new D_ProductoDetalleImpuestos());
            modelBuilder.ApplyConfiguration(new D_ProductoDetallePrecios());

            //MODULO ALMACEN
            modelBuilder.ApplyConfiguration(new D_Inventario());


        }


    }
}
