using $safeprojectname$.$safeprojectname$.APIContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace $safeprojectname$.$safeprojectname$.APIContext.Configurations
{
    public class UsuariosConfiguration : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder) 
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("Usuarios", "dbo");

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Name).HasMaxLength(100);
            builder.Property(e => e.Telefono).HasMaxLength(12);

            builder.Property(e => e.Activo).HasDefaultValueSql("((1))");

            //Definicion de un Filtro Global para las consultas 
            builder.HasQueryFilter(c => c.Activo == 1);
        }
    }
}
