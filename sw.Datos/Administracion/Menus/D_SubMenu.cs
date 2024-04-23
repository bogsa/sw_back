using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sw.Entidades.Administracion.Menus;
using System;
using System.Collections.Generic;
using System.Text;

namespace sw.Datos.Administracion.Menus
{
    public class D_SubMenu : IEntityTypeConfiguration<E_SubMenu>
    {
        public void Configure(EntityTypeBuilder<E_SubMenu> builder)
        {
            builder.ToTable("Admin_SubMenu")
                 .HasKey(a => a.IdSubMenu);

            builder.Property(a => a.IdSubMenu)
            .HasDefaultValueSql("newId()");

        }
    }
}
