 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sw.Entidades.Almacen.Categoria;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Almacen.Categoria
{
    public class D_Categoria : IEntityTypeConfiguration<E_Categoria>
    {
        public void Configure(EntityTypeBuilder<E_Categoria> builder)
        {

            builder.ToTable("Alm_Categoria")
                   .HasKey(a => a.IdCategoria);


        }
    }
}
