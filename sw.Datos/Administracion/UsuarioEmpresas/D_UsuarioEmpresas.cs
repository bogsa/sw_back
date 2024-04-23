using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sw.Entidades.Administracion.UsuarioEmpresas;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Administracion.UsuarioEmpresas
{
    public class D_UsuarioEmpresas : IEntityTypeConfiguration<E_UsuarioEmpresas>
    {
        public void Configure(EntityTypeBuilder<E_UsuarioEmpresas> builder)
        {
            builder.ToTable("Admin_UsuarioEmpresas")
                      .HasKey(a => a.IdUsuarioEmpresa);
 
        }
    }
}
