using sw.Entidades.Configuracion.CatalogoSAT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Configuracion.CatalogoSAT
{
    public class D_RegimenFiscal : IEntityTypeConfiguration<E_RegimenFiscal>
    {
        public void Configure(EntityTypeBuilder<E_RegimenFiscal> builder)
        {

            builder.ToTable("Conf_RegimenFiscal")
                   .HasKey(a => a.IdRegimenFiscal);

            builder.Property(a => a.Clave)
                  .HasColumnType("nvarchar(20)");



        }
    }
}
