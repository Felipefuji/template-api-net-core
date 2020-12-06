using $safeprojectname$.$safeprojectname$.APIContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace $safeprojectname$.$safeprojectname$.APIContext.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder) 
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("Usuarios", "dbo");

            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Name).HasMaxLength(100);
            builder.Property(e => e.Phone).HasMaxLength(12);

            builder.Property(e => e.IsEnable).HasDefaultValueSql("((1))");

            //Definicion de un Filtro Global para las consultas 
            builder.HasQueryFilter(c => c.IsEnable == 1);
        }
    }
}
