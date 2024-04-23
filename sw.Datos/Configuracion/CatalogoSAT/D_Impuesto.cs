using sw.Entidades.Configuracion.CatalogoSAT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Configuracion.CatalogoSAT
{
    public class D_Impuesto : IEntityTypeConfiguration<E_Impuesto>
    {
        public void Configure(EntityTypeBuilder<E_Impuesto> builder)
        {

            builder.ToTable("Conf_Impuesto")
                   .HasKey(a => a.IdImpuesto);

            
            builder.Property(a => a.Clave)
                  .HasColumnType("NvarChar(20)");
        }
    }
}
