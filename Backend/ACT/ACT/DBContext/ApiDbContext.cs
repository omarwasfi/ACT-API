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


        public DbSet<HRMS_Configuration_Model> HRMS_Configuration_Models { get; set; }

        public DbSet<HRMS_DETAIL_Model> HRMS_DETAIL_Models { get; set; }

        public DbSet<HRMS_HDR_Model> HRMS_HDR_Models { get; set; }
        public DbSet<HRMS_Column_Model> HRMS_Columns { get; set; }


        public DbSet<OPERA_Configuration_Model> OPERA_Configuration_Models { get; set; }

        public DbSet<OPERA_DETAIL_Model> OPERA_DETAIL_Models { get; set; }

        public DbSet<OPERA_HDR_Model> OPERA_HDR_Models { get; set; }
        public DbSet<OPERA_Column_Model> OPERA_Columns { get; set; }


        public DbSet<SUN_Configuration_Model> SUN_Configuration_Models { get; set; }
        public DbSet<SUN_Column_Model> SUN_Columns { get; set; }


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
              .HasMany(o => o.Columns)
              .WithOne(s => s.SUN_Configuration)
              .OnDelete(DeleteBehavior.SetNull);
        }

    }
}
