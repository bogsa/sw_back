using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sw.Entidades.Administracion.TFDs;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Administracion.TFDs
{
    public class D_TFDsGlobal : IEntityTypeConfiguration<E_TFDsGlobal>
    {
        public void Configure(EntityTypeBuilder<E_TFDsGlobal> builder)
        {
            builder.ToTable("Admin_TFDsGlobal")
                 .HasKey(a => a.IdTFDsGlobal);
        }
    }
}
