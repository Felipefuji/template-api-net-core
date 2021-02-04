using Data.Data.APIContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Data.APIContext.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("Client", "dbo");

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.Cif)
                .HasColumnName("CIF")
                .HasMaxLength(50);

            builder.Property(e => e.Code).HasMaxLength(50);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(e => e.Telephone).HasMaxLength(50);

            builder.Property(e => e.IsEnable).HasDefaultValueSql("((1))");

            //Definicion de un Filtro Global para las consultas 
            builder.HasQueryFilter(c => c.IsEnable == 1);

        }
    }
}
