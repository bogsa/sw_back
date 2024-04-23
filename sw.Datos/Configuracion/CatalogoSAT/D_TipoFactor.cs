using sw.Entidades.Configuracion.CatalogoSAT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace sw.Datos.Configuracion.CatalogoSAT
{
    public class D_TipoFactor : IEntityTypeConfiguration<E_TipoFactor>
    {
        public void Configure(EntityTypeBuilder<E_TipoFactor> builder)
        {

            builder.ToTable("Conf_TipoFactor")
                   .HasKey(a => a.IdTipoFactor);

            builder.Property(a => a.Clave)
                  .HasColumnType("NvarChar(20)");


        }
    }
}