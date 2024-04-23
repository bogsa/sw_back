using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sw.Entidades.Administracion.PerfilesPer;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Administracion.PerfilesPer
{
    public class D_Modulo : IEntityTypeConfiguration<E_Modulo>
    {
        public void Configure(EntityTypeBuilder<E_Modulo> builder)
        {
            builder.ToTable("Admin_Modulo")
                     .HasKey(a => a.IdModulo);
        }
    }
}
