using sw.Entidades.Configuracion.CatalogoSAT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Configuracion.CatalogoSAT
{
    public class D_UnidadMedida : IEntityTypeConfiguration<E_UnidadMedida>
    {
        public void Configure(EntityTypeBuilder<E_UnidadMedida> builder)
        {

            builder.ToTable("Conf_UnidadMedida")
                   .HasKey(a => a.IdUnidadMedida);

            builder.Property(a => a.Clave)
                  .HasColumnType("nvarchar(20)");
        }
    }
}
