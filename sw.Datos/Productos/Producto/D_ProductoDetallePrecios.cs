using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sw.Entidades.Productos.Producto;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Productos.Producto
{
    public class D_ProductoDetallePrecios : IEntityTypeConfiguration<E_ProductoDetallePrecios>
    {
        public void Configure(EntityTypeBuilder<E_ProductoDetallePrecios> builder)
        { 
            builder.ToTable("Pro_ProductoDetallePrecios")
                   .HasKey(a => a.IdProductoDetallePrecios); 
        }
    }
}
