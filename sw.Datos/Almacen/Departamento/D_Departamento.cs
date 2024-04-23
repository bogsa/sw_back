 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sw.Entidades.Almacen.Departamento;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Almacen.Departamento
{
    public class D_Departamento : IEntityTypeConfiguration<E_Departamento>
    {
        public void Configure(EntityTypeBuilder<E_Departamento> builder)
        {

            builder.ToTable("Alm_Departamento")
                   .HasKey(a => a.IdDepartamento);

        }
    }
}
