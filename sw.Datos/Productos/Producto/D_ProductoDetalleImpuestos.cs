using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sw.Entidades.Productos.Producto;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Productos.Producto
{
    public class D_ProductoDetalleImpuestos : IEntityTypeConfiguration<E_ProductoDetalleImpuestos>
    {
        public void Configure(EntityTypeBuilder<E_ProductoDetalleImpuestos> builder)
        { 
            builder.ToTable("Pro_ProductoDetalleImpuestos")
                   .HasKey(a => a.IdProductoDetalleImpuestos); 
        }
    }
}
