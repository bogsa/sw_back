

using sw.Entidades.Clientes.ClienteDatoFiscal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using sw.Entidades.Clientes.Cliente;

namespace sw.Datos.Clientes.ClienteDatoFiscal
{
    public class D_ClienteDatosFiscales : IEntityTypeConfiguration<E_ClienteDatosFiscales>
    {
        public void Configure(EntityTypeBuilder<E_ClienteDatosFiscales> builder)
        {

            builder.ToTable("Cli_ClienteDatosFiscales")
                   .HasKey(a => a.IdClienteDatosFiscales);


        }
    }
}