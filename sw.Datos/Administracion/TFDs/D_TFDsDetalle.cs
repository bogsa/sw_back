using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sw.Entidades.Administracion.TFDs;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Administracion.TFDs
{
    public class D_TFDsDetalle : IEntityTypeConfiguration<E_TFDsDetalle>
    {
        public void Configure(EntityTypeBuilder<E_TFDsDetalle> builder)
        {
            builder.ToTable("Admin_TFDsDetalle")
                 .HasKey(a => a.IdDetalleTFD);
        }
    }
}
