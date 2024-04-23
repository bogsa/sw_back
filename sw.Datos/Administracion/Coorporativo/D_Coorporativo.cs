using sw.Entidades.Administracion.Coorporativo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Administracion.Coorporativo
{
    public class D_Coorporativo : IEntityTypeConfiguration<E_Coorporativo>
    {
        public void Configure(EntityTypeBuilder<E_Coorporativo> builder)
        { 
            builder.ToTable("Admin_Coorporativo")
                   .HasKey(a => a.IdCoorporativo); 

        }
    }
 
}
