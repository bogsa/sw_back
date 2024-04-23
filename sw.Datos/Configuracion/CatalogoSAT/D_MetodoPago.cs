using sw.Entidades.Configuracion.CatalogoSAT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace sw.Datos.Configuracion.CatalogoSAT
{
    public class D_MetodoPago : IEntityTypeConfiguration<E_MetodoPago>
    {
        public void Configure(EntityTypeBuilder<E_MetodoPago> builder)
        {

            builder.ToTable("Conf_MetodoPago")
                   .HasKey(a => a.IdMetodoPago);

            builder.Property(a => a.Clave)
                  .HasColumnType("NvarChar(20)");


        }
    }
}