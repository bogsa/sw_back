using sw.Entidades.Configuracion.CatalogoSAT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace sw.Datos.Configuracion.CatalogoSAT
{
    public class D_Moneda : IEntityTypeConfiguration<E_Moneda>
    {
        public void Configure(EntityTypeBuilder<E_Moneda> builder)
        {

            builder.ToTable("Conf_Moneda")
                   .HasKey(a => a.IdMoneda);

            builder.Property(a => a.Clave)
                  .HasColumnType("NvarChar(20)");

        }
    }
}
