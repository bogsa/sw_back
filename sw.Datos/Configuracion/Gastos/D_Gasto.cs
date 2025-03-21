using Microsoft.EntityFrameworkCore;
using sw.Entidades.Configuracion.Gastos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sw.Datos.Configuracion.Gastos
{
    public class D_Gasto : IEntityTypeConfiguration<E_Gasto>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<E_Gasto> builder)
        {
            builder.ToTable("Conf_Gasto")
                   .HasKey(a => a.IdGasto);
             
        }
    }
}
