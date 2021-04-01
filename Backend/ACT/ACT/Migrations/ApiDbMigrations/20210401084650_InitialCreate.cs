using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACT.Migrations.ApiDbMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HRMS_Configuration_Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConnectionsString = table.Column<string>(type: "TEXT", nullable: true),
                    CycleTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HRMS_Configuration_Models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HRMS_DETAIL_Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SunAttribute = table.Column<string>(type: "TEXT", nullable: true),
                    IsConst = table.Column<bool>(type: "INTEGER", nullable: false),
                    ValueType = table.Column<string>(type: "TEXT", nullable: true),
                    IntValue = table.Column<int>(type: "INTEGER", nullable: false),
                    ShortValue = table.Column<short>(type: "INTEGER", nullable: false),
                    DateTimeValue = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StringValue = table.Column<string>(type: "TEXT", nullable: true),
                    DecimalValue = table.Column<decimal>(type: "TEXT", nullable: false),
                    MapWithHRMS = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HRMS_DETAIL_Models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HRMS_HDR_Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SunAttribute = table.Column<string>(type: "TEXT", nullable: true),
                    IsConst = table.Column<bool>(type: "INTEGER", nullable: false),
                    ValueType = table.Column<string>(type: "TEXT", nullable: true),
                    IntValue = table.Column<int>(type: "INTEGER", nullable: false),
                    ShortValue = table.Column<short>(type: "INTEGER", nullable: false),
                    DateTimeValue = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StringValue = table.Column<string>(type: "TEXT", nullable: true),
                    DecimalValue = table.Column<decimal>(type: "TEXT", nullable: false),
                    MapWithHRMS = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HRMS_HDR_Models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OPERA_Configuration_Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilePath = table.Column<string>(type: "TEXT", nullable: true),
                    CycleTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERA_Configuration_Models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OPERA_DETAIL_Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SunAttribute = table.Column<string>(type: "TEXT", nullable: true),
                    IsConst = table.Column<bool>(type: "INTEGER", nullable: false),
                    ValueType = table.Column<string>(type: "TEXT", nullable: true),
                    IntValue = table.Column<int>(type: "INTEGER", nullable: false),
                    ShortValue = table.Column<short>(type: "INTEGER", nullable: false),
                    DateTimeValue = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StringValue = table.Column<string>(type: "TEXT", nullable: true),
                    DecimalValue = table.Column<decimal>(type: "TEXT", nullable: false),
                    MapWithHRMS = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERA_DETAIL_Models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OPERA_HDR_Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SunAttribute = table.Column<string>(type: "TEXT", nullable: true),
                    IsConst = table.Column<bool>(type: "INTEGER", nullable: false),
                    ValueType = table.Column<string>(type: "TEXT", nullable: true),
                    IntValue = table.Column<int>(type: "INTEGER", nullable: false),
                    ShortValue = table.Column<short>(type: "INTEGER", nullable: false),
                    DateTimeValue = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StringValue = table.Column<string>(type: "TEXT", nullable: true),
                    DecimalValue = table.Column<decimal>(type: "TEXT", nullable: false),
                    MapWithHRMS = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERA_HDR_Models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SUN_Configuration_Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConnectionsString = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUN_Configuration_Models", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HRMS_Configuration_Models");

            migrationBuilder.DropTable(
                name: "HRMS_DETAIL_Models");

            migrationBuilder.DropTable(
                name: "HRMS_HDR_Models");

            migrationBuilder.DropTable(
                name: "OPERA_Configuration_Models");

            migrationBuilder.DropTable(
                name: "OPERA_DETAIL_Models");

            migrationBuilder.DropTable(
                name: "OPERA_HDR_Models");

            migrationBuilder.DropTable(
                name: "SUN_Configuration_Models");
        }
    }
}
