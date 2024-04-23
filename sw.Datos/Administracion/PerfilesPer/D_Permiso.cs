using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sw.Entidades.Administracion.PerfilesPer;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Administracion.PerfilesPer
{
    public class D_Permiso : IEntityTypeConfiguration<E_Permiso>
    {
        public void Configure(EntityTypeBuilder<E_Permiso> builder)
        {
            builder.ToTable("Admin_Permiso")
                     .HasKey(a => a.IdPermiso);
        }
    }
}
