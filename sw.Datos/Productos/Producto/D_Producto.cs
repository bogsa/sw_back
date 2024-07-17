using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 
using sw.Entidades.Productos.Producto;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Productos.Producto
{
    public class D_Producto : IEntityTypeConfiguration<E_Producto>
    {
        public void Configure(EntityTypeBuilder<E_Producto> builder)
        { 
            builder.ToTable("Pro_Producto")
                   .HasKey(a => a.IdProducto);
                  
        }
    }
}
