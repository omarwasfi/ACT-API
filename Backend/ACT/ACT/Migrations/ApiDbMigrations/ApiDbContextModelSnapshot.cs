﻿// <auto-generated />
using System;
using ACT.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ACT.Migrations.ApiDbMigrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("ACT.DataModels.HRMS_Configuration_Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConnectionsString")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CycleTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("HRMS_Configurations");
                });

            modelBuilder.Entity("ACT.DataModels.HRMS_REPORT_Column_Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ColumnName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("HRMS_ConfigurationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("HRMS_ConfigurationId");

                    b.ToTable("HRMS_REPORT_Columns");
                });

            modelBuilder.Entity("ACT.DataModels.HRMS_REPORT_SUN_DETAIL_Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AutoGenerated")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateTimeValue")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("DecimalValue")
                        .HasColumnType("TEXT");

                    b.Property<double?>("DoubleValue")
                        .HasColumnType("REAL");

                    b.Property<int?>("IntValue")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsConst")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MapWithHRMS")
                        .HasColumnType("TEXT");

                    b.Property<short?>("ShortValue")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StringValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("SunAttribute")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ValueType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("HRMS_REPORT_SUN_DETAILS");
                });

            modelBuilder.Entity("ACT.DataModels.HRMS_REPORT_SUN_HDR_Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AutoGenerated")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateTimeValue")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("DecimalValue")
                        .HasColumnType("TEXT");

                    b.Property<double?>("DoubleValue")
                        .HasColumnType("REAL");

                    b.Property<int?>("IntValue")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsConst")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MapWithHRMS")
                        .HasColumnType("TEXT");

                    b.Property<short?>("ShortValue")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StringValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("SunAttribute")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ValueType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("HRMS_REPORT_SUN_HDRS");
                });

            modelBuilder.Entity("ACT.DataModels.OPERA_Configuration_Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CycleTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberOfLinesToBeIgnoredAtTheBeginning")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfLinesToBeIgnoredAtTheEnd")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("OPERA_Configurations");
                });

            modelBuilder.Entity("ACT.DataModels.OPERA_REPORT_Column_Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ColumnName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EndPOS")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OPERA_ConfigurationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StartPOS")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OPERA_ConfigurationId");

                    b.ToTable("OPERA_REPORT_Columns");
                });

            modelBuilder.Entity("ACT.DataModels.OPERA_REPORT_SUN_DETAIL_Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AutoGenerated")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateTimeValue")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("DecimalValue")
                        .HasColumnType("TEXT");

                    b.Property<double?>("DoubleValue")
                        .HasColumnType("REAL");

                    b.Property<int?>("IntValue")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsConst")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MapWithOPERA")
                        .HasColumnType("TEXT");

                    b.Property<short?>("ShortValue")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StringValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("SunAttribute")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ValueType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("OPERA_REPORT_SUN_DETAILS");
                });

            modelBuilder.Entity("ACT.DataModels.OPERA_REPORT_SUN_HDR_Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AutoGenerated")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateTimeValue")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("DecimalValue")
                        .HasColumnType("TEXT");

                    b.Property<double?>("DoubleValue")
                        .HasColumnType("REAL");

                    b.Property<int?>("IntValue")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsConst")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MapWithOPERA")
                        .HasColumnType("TEXT");

                    b.Property<short?>("ShortValue")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StringValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("SunAttribute")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ValueType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("OPERA_REPORT_SUN_HDRS");
                });

            modelBuilder.Entity("ACT.DataModels.SUN_Configuration_Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConnectionsString")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SUN_Configurations");
                });

            modelBuilder.Entity("ACT.DataModels.SUN_DETAIL_Column_Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ColumnName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("SUN_ConfigurationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SUN_ConfigurationId");

                    b.ToTable("SUN_DETAIL_Columns");
                });

            modelBuilder.Entity("ACT.DataModels.SUN_HDR_Column_Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ColumnName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("SUN_ConfigurationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SUN_ConfigurationId");

                    b.ToTable("SUN_HDR_Columns");
                });

            modelBuilder.Entity("ACT.DataModels.HRMS_REPORT_Column_Model", b =>
                {
                    b.HasOne("ACT.DataModels.HRMS_Configuration_Model", "HRMS_Configuration")
                        .WithMany("Columns")
                        .HasForeignKey("HRMS_ConfigurationId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("HRMS_Configuration");
                });

            modelBuilder.Entity("ACT.DataModels.OPERA_REPORT_Column_Model", b =>
                {
                    b.HasOne("ACT.DataModels.OPERA_Configuration_Model", "OPERA_Configuration")
                        .WithMany("Columns")
                        .HasForeignKey("OPERA_ConfigurationId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("OPERA_Configuration");
                });

            modelBuilder.Entity("ACT.DataModels.SUN_DETAIL_Column_Model", b =>
                {
                    b.HasOne("ACT.DataModels.SUN_Configuration_Model", "SUN_Configuration")
                        .WithMany("DETAIL_Columns")
                        .HasForeignKey("SUN_ConfigurationId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("SUN_Configuration");
                });

            modelBuilder.Entity("ACT.DataModels.SUN_HDR_Column_Model", b =>
                {
                    b.HasOne("ACT.DataModels.SUN_Configuration_Model", "SUN_Configuration")
                        .WithMany("HDR_Columns")
                        .HasForeignKey("SUN_ConfigurationId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("SUN_Configuration");
                });

            modelBuilder.Entity("ACT.DataModels.HRMS_Configuration_Model", b =>
                {
                    b.Navigation("Columns");
                });

            modelBuilder.Entity("ACT.DataModels.OPERA_Configuration_Model", b =>
                {
                    b.Navigation("Columns");
                });

            modelBuilder.Entity("ACT.DataModels.SUN_Configuration_Model", b =>
                {
                    b.Navigation("DETAIL_Columns");

                    b.Navigation("HDR_Columns");
                });
#pragma warning restore 612, 618
        }
    }
}
