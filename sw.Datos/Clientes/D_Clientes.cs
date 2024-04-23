

using sw.Entidades.Clientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Clientes
{
    public class D_Clientes : IEntityTypeConfiguration<E_Clientes>
    {
        public void Configure(EntityTypeBuilder<E_Clientes> builder)
        {

            builder.ToTable("Cli_Clientes")
                   .HasKey(a => a.IdCliente);


        }
    }
}
