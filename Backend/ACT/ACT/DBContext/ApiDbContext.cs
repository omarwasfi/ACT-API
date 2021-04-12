using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACT.DataModels;

namespace ACT.DBContext
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {
            
        }


        public DbSet<HRMS_Configuration_Model> HRMS_Configurations { get; set; }
         
        public DbSet<HRMS_REPORT_SUN_DETAIL_Model> HRMS_REPORT_SUN_DETAILS { get; set; }

        public DbSet<HRMS_REPORT_SUN_HDR_Model> HRMS_REPORT_SUN_HDRS { get; set; }
        public DbSet<HRMS_REPORT_Column_Model> HRMS_REPORT_Columns { get; set; }


        public DbSet<OPERA_Configuration_Model> OPERA_Configurations { get; set; }

        public DbSet<OPERA_REPORT_SUN_DETAIL_Model> OPERA_REPORT_SUN_DETAILS { get; set; }

        public DbSet<OPERA_REPORT_SUN_HDR_Model> OPERA_REPORT_SUN_HDRS { get; set; }
        public DbSet<OPERA_REPORT_Column_Model> OPERA_REPORT_Columns { get; set; }


        public DbSet<SUN_Configuration_Model> SUN_Configurations { get; set; }
        public DbSet<SUN_HDR_Column_Model> SUN_HDR_Columns { get; set; }
        public DbSet<SUN_DETAIL_Column_Model> SUN_DETAIL_Columns { get; set; }
        public DbSet<ExecutionHistory_Model> ExecutionHistories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies(true);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<HRMS_Configuration_Model>() 
               .HasMany(o => o.Columns)
               .WithOne(s => s.HRMS_Configuration)
               .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<OPERA_Configuration_Model>()
               .HasMany(o => o.Columns)
               .WithOne(s => s.OPERA_Configuration)
               .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<SUN_Configuration_Model>()
              .HasMany(o => o.HDR_Columns)
              .WithOne(s => s.SUN_Configuration)
              .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<SUN_Configuration_Model>()
            .HasMany(o => o.DETAIL_Columns)
            .WithOne(s => s.SUN_Configuration)
            .OnDelete(DeleteBehavior.SetNull);

               builder.Entity<OPERA_Configuration_Model>()
              .HasMany(o => o.Columns)
              .WithOne(s => s.OPERA_Configuration)
              .OnDelete(DeleteBehavior.SetNull);

             builder.Entity<HRMS_Configuration_Model>()
            .HasMany(o => o.Columns)
            .WithOne(s => s.HRMS_Configuration)
            .OnDelete(DeleteBehavior.SetNull);
        }



    }
}
