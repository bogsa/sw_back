 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sw.Entidades.Productos.Departamento;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Productos.Departamento
{
    public class D_Departamento : IEntityTypeConfiguration<E_Departamento>
    {
        public void Configure(EntityTypeBuilder<E_Departamento> builder)
        {

            builder.ToTable("Pro_Departamento")
                   .HasKey(a => a.IdDepartamento);

        }
    }
}
