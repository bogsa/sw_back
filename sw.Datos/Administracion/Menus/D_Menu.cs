using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sw.Entidades.Administracion.Menus;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Administracion.Menus
{
    public class D_Menu : IEntityTypeConfiguration<E_Menu>
    {
        public void Configure(EntityTypeBuilder<E_Menu> builder)
        {
            builder.ToTable("Admin_Menu")
                 .HasKey(a => a.IdMenu);


            


        }
    }
}
