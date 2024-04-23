using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sw.Entidades.Almacen.Articulo; 
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Almacen.Articulo
{
    public class D_ArticulosDetalleImpuestos : IEntityTypeConfiguration<E_ArticuloDetalleImpuestos>
    {
        public void Configure(EntityTypeBuilder<E_ArticuloDetalleImpuestos> builder)
        { 
            builder.ToTable("Alm_ArticuloDetalleImpuestos")
                   .HasKey(a => a.IdArticuloDetalleImpuestos); 
        }
    }
}
