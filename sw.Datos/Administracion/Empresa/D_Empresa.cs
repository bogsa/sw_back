using sw.Entidades.Administracion.Empresa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Administracion.Empresa
{
    public class D_Empresa : IEntityTypeConfiguration<E_Empresa>
    {
        public void Configure(EntityTypeBuilder<E_Empresa> builder)
        {

            builder.ToTable("Admin_Empresa")
                   .HasKey(a => a.IdEmpresa);


        }
    }
}
