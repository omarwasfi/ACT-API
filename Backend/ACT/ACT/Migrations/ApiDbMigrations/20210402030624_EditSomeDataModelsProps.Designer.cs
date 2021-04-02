﻿// <auto-generated />
using System;
using ACT.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ACT.Migrations.ApiDbMigrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20210402030624_EditSomeDataModelsProps")]
    partial class EditSomeDataModelsProps
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.ToTable("HRMS_Configuration_Models");
                });

            modelBuilder.Entity("ACT.DataModels.HRMS_DETAIL_Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateTimeValue")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("DecimalValue")
                        .HasColumnType("TEXT");

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
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("HRMS_DETAIL_Models");
                });

            modelBuilder.Entity("ACT.DataModels.HRMS_HDR_Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateTimeValue")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("DecimalValue")
                        .HasColumnType("TEXT");

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
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("HRMS_HDR_Models");
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

                    b.HasKey("Id");

                    b.ToTable("OPERA_Configuration_Models");
                });

            modelBuilder.Entity("ACT.DataModels.OPERA_DETAIL_Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateTimeValue")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("DecimalValue")
                        .HasColumnType("TEXT");

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
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("OPERA_DETAIL_Models");
                });

            modelBuilder.Entity("ACT.DataModels.OPERA_HDR_Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateTimeValue")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("DecimalValue")
                        .HasColumnType("TEXT");

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
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("OPERA_HDR_Models");
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

                    b.ToTable("SUN_Configuration_Models");
                });
#pragma warning restore 612, 618
        }
    }
}