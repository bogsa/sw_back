using sw.Entidades.Configuracion.CatalogoSAT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace sw.Datos.Configuracion.CatalogoSAT
{
    public class D_FormaPago : IEntityTypeConfiguration<E_FormaPago>
    {
        public void Configure(EntityTypeBuilder<E_FormaPago> builder)
        {

            builder.ToTable("Conf_FormaPago")
                   .HasKey(a => a.IdFormaPago);

            builder.Property(a => a.Clave)
                  .HasColumnType("NvarChar(20)");


        }
    }
}
