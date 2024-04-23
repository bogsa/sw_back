using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sw.Entidades.Almacen.Inventario;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Almacen.Inventario
{
    public class D_InventarioDetallePrecios : IEntityTypeConfiguration<E_InventarioDetallePrecios>
    {
        public void Configure(EntityTypeBuilder<E_InventarioDetallePrecios> builder)
        { 
            builder.ToTable("Alm_InventarioDetallePrecios")
                   .HasKey(a => a.IdInventarioDetallePrecios); 
        }
    }
}
