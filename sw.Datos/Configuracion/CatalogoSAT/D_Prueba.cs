using sw.Entidades.Configuracion.CatalogoSAT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace sw.Datos.Configuracion.CatalogoSAT
{
    public class D_Prueba : IEntityTypeConfiguration<E_Prueba>
    {
        public void Configure(EntityTypeBuilder<E_Prueba> builder)
        {

            builder.ToTable("Conf_Prueba")
                   .HasKey(a => a.IdPrueba);

          


        }
    }
}
