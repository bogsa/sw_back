using sw.Entidades.Configuracion.CatalogoSAT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Configuracion.CatalogoSAT
{
    public class D_TipoComprobante : IEntityTypeConfiguration<E_TipoComprobante>
    {
        public void Configure(EntityTypeBuilder<E_TipoComprobante> builder)
        {

            builder.ToTable("Conf_TipoComprobante")
                   .HasKey(a => a.IdTipoComprobante);

            builder.Property(a => a.Clave)
                  .HasColumnType("nvarchar(20)");
        }
    }
}
