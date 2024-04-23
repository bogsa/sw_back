using sw.Entidades.Configuracion.CatalogoSAT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace sw.Datos.Configuracion.CatalogoSAT
{
    public class D_ObjetoImpuesto : IEntityTypeConfiguration<E_ObjetoImpuesto>
    {
        public void Configure(EntityTypeBuilder<E_ObjetoImpuesto> builder)
        {

            builder.ToTable("Conf_ObjetoImpuesto")
                   .HasKey(a => a.IdObjetoImpuesto);

            builder.Property(a => a.Clave)
                  .HasColumnType("NvarChar(20)");


        }
    }
}