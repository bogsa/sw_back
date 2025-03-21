using System;
using sw.Entidades.Gastos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sw.Entidades.Configuracion.Gastos;

namespace sw.Datos.Gastos
{
    public class D_Gastoreg : IEntityTypeConfiguration<E_Gastoreg>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<E_Gastoreg> builder)
        {
            builder.ToTable("Gas_Gasto")
                   .HasKey(a => a.IdGastoreg);

        }
    }
}
