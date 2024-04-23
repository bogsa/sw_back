
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sw.Entidades.Almacen.Inventario; 

namespace sw.Datos.Almacen.Inventario
{
    public class D_Inventario : IEntityTypeConfiguration<E_Inventario>
    {
        public void Configure(EntityTypeBuilder<E_Inventario> builder)
        { 
            builder.ToTable("Alm_Inventario")
                   .HasKey(a => a.IdInventario);      
        }
    }
}
