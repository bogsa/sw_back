
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sw.Entidades.Configuracion.Productos;
using System;
using System.Collections.Generic;
using System.Text;


namespace sw.Datos.Configuracion.Productos
{
    public class D_Proveedor : IEntityTypeConfiguration<E_Proveedor>
    {
        public void Configure(EntityTypeBuilder<E_Proveedor> builder)
        {

            builder.ToTable("Pro_Proveedor")
                   .HasKey(a => a.IdProveedor);
 


        }
    }
}
