
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using sw.Entidades.Administracion.CentroTrabajo;

namespace sw.Datos.Administracion.CentroTrabajo
{
    public class D_CentroTrabajo : IEntityTypeConfiguration<E_CentroTrabajo>
    {
        public void Configure(EntityTypeBuilder<E_CentroTrabajo> builder)
        {

            builder.ToTable("Admin_CentroTrabajo")
                       .HasKey(a => a.IdCentroTrabajo);


        }
    }
}
