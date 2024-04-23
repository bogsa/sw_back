using sw.Entidades.Configuracion.CatalogoSAT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
namespace sw.Datos.Configuracion.CatalogoSAT
{
    public class D_ProductoServicio : IEntityTypeConfiguration<E_ProductoServicio>
    {
        public void Configure(EntityTypeBuilder<E_ProductoServicio> builder)
        {

            builder.ToTable("Conf_ProductoServicio")
                   .HasKey(a => a.IdProductoServicio);

            builder.Property(a => a.Clave)
                  .HasColumnType("nvarchar(20)");
          


        }
    }
}
