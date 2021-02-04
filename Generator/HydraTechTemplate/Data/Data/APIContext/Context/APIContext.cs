using $safeprojectname$.$safeprojectname$.APIContext.Configurations;
using $safeprojectname$.$safeprojectname$.APIContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace $safeprojectname$.$safeprojectname$.APIContext.Context
{
    public partial class APIContext : DbContext
    {
        public APIContext() 
        {
        }

        public APIContext(DbContextOptions<APIContext> options) 
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }

        #region DbQuery
        // En esta region se pueden crear DbSet virtuales de consultas, por ejemplo para realizar un FromSql
        //public virtual DbSet<AnalysisListQuery> AnalysisListQuery { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "db_owner");
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            //modelBuilder.Entity<AnalysisListQuery>().HasNoKey();
        }
    }
}
