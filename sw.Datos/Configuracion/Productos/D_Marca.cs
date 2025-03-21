using sw.Entidades.Configuracion.Productos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace sw.Datos.Configuracion.Productos
{
    public class D_Marca : IEntityTypeConfiguration<E_Marca>
    {
        public void Configure(EntityTypeBuilder<E_Marca> builder)
        {
            builder.ToTable("Pro_Marca")
                   .HasKey(a => a.IdMarca);
 
        }
    }
}
