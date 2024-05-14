 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sw.Entidades.Articulos.Categoria;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Articulos.Categoria
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
