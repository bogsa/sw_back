using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sw.Entidades.Articulos.Articulo; 
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Articulos.Articulo
{
    public class D_Articulo : IEntityTypeConfiguration<E_Articulo>
    {
        public void Configure(EntityTypeBuilder<E_Articulo> builder)
        { 
            builder.ToTable("Alm_Articulo")
                   .HasKey(a => a.IdArticulo);
                  
        }
    }
}
