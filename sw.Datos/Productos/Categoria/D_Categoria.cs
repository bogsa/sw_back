 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sw.Entidades.Productos.Categoria;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Productos.Categoria
{
    public class D_Categoria : IEntityTypeConfiguration<E_Categoria>
    {
        public void Configure(EntityTypeBuilder<E_Categoria> builder)
        {

            builder.ToTable("Pro_Categoria")
                   .HasKey(a => a.IdCategoria);


        }
    }
}
