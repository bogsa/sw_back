using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sw.Entidades.Administracion.PerfilesPer;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Administracion.PerfilesPer
{
    public class D_Prefil : IEntityTypeConfiguration<E_Perfil>
    {
        public void Configure(EntityTypeBuilder<E_Perfil> builder)
        {
            builder.ToTable("Admin_Perfil")
                           .HasKey(a => a.IdPerfil);
        }
    }
}
