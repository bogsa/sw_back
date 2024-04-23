
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sw.Entidades.Administracion.TFDs;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Administracion.TFDs
{
    public class D_AsignacionTFD : IEntityTypeConfiguration<E_AsignacionTFD>
    {
        public void Configure(EntityTypeBuilder<E_AsignacionTFD> builder)
        {
            builder.ToTable("Admin_AsignacionTFD")
               .HasKey(a => a.IdAsignacionTFDs);
        }
    }
}
