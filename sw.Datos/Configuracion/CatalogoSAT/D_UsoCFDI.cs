using sw.Entidades.Configuracion.CatalogoSAT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Configuracion.CatalogoSAT
{
    public class D_UsoCFDI : IEntityTypeConfiguration<E_UsoCFDI>
    {
        public void Configure(EntityTypeBuilder<E_UsoCFDI> builder)
        {

            builder.ToTable("Conf_UsoCFDI")
                   .HasKey(a => a.IdUsoCFDI);

            builder.Property(a => a.Clave)
                  .HasColumnType("nvarchar(20)");

        }
    }
}
