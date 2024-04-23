using sw.Entidades.Configuracion.CatalogoSAT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Configuracion.CatalogoSAT
{
    public class D_TipoRelacion : IEntityTypeConfiguration<E_TipoRelacion>
    {
        public void Configure(EntityTypeBuilder<E_TipoRelacion> builder)
        {

            builder.ToTable("Conf_TipoRelacion")
                   .HasKey(a => a.IdTipoRelacion);

            builder.Property(a => a.Clave)
                  .HasColumnType("nvarchar(20)");
        }
    }
}
