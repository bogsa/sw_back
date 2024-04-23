using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sw.Entidades.Administracion.UsuarioCentroTrabajoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Administracion.UsuarioCentroTrabajoes
{
    internal class D_UsuarioCentroTrabajoes : IEntityTypeConfiguration<E_UsuarioCentroTrabajoes>
    {
        public void Configure(EntityTypeBuilder<E_UsuarioCentroTrabajoes> builder)
        {
            builder.ToTable("Admin_UsuarioCentroTrabajo")
                  .HasKey(a => a.IdUsuarioCentroTrabajo);
        }
    }
}
