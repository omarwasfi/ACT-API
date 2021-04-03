using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACT.Migrations.ApiDbMigrations
{
    public partial class SupportBothHDRAndDetailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HRMS_Configuration_Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConnectionsString = table.Column<string>(type: "TEXT", nullable: false),
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
                    SunAttribute = table.Column<string>(type: "TEXT", nullable: false),
                    IsConst = table.Column<bool>(type: "INTEGER", nullable: false),
                    ValueType = table.Column<string>(type: "TEXT", nullable: true),
                    IntValue = table.Column<int>(type: "INTEGER", nullable: true),
                    ShortValue = table.Column<short>(type: "INTEGER", nullable: true),
                    DateTimeValue = table.Column<DateTime>(type: "TEXT", nullable: true),
                    StringValue = table.Column<string>(type: "TEXT", nullable: true),
                    DecimalValue = table.Column<decimal>(type: "TEXT", nullable: true),
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
                    SunAttribute = table.Column<string>(type: "TEXT", nullable: false),
                    IsConst = table.Column<bool>(type: "INTEGER", nullable: false),
                    ValueType = table.Column<string>(type: "TEXT", nullable: true),
                    IntValue = table.Column<int>(type: "INTEGER", nullable: true),
                    ShortValue = table.Column<short>(type: "INTEGER", nullable: true),
                    DateTimeValue = table.Column<DateTime>(type: "TEXT", nullable: true),
                    StringValue = table.Column<string>(type: "TEXT", nullable: true),
                    DecimalValue = table.Column<decimal>(type: "TEXT", nullable: true),
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
                    FilePath = table.Column<string>(type: "TEXT", nullable: false),
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
                    SunAttribute = table.Column<string>(type: "TEXT", nullable: false),
                    IsConst = table.Column<bool>(type: "INTEGER", nullable: false),
                    ValueType = table.Column<string>(type: "TEXT", nullable: true),
                    IntValue = table.Column<int>(type: "INTEGER", nullable: true),
                    ShortValue = table.Column<short>(type: "INTEGER", nullable: true),
                    DateTimeValue = table.Column<DateTime>(type: "TEXT", nullable: true),
                    StringValue = table.Column<string>(type: "TEXT", nullable: true),
                    DecimalValue = table.Column<decimal>(type: "TEXT", nullable: true),
                    MapWithOPERA = table.Column<string>(type: "TEXT", nullable: true)
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
                    SunAttribute = table.Column<string>(type: "TEXT", nullable: false),
                    IsConst = table.Column<bool>(type: "INTEGER", nullable: false),
                    ValueType = table.Column<string>(type: "TEXT", nullable: true),
                    IntValue = table.Column<int>(type: "INTEGER", nullable: true),
                    ShortValue = table.Column<short>(type: "INTEGER", nullable: true),
                    DateTimeValue = table.Column<DateTime>(type: "TEXT", nullable: true),
                    StringValue = table.Column<string>(type: "TEXT", nullable: true),
                    DecimalValue = table.Column<decimal>(type: "TEXT", nullable: true),
                    MapWithOPERA = table.Column<string>(type: "TEXT", nullable: true)
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
                    ConnectionsString = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUN_Configuration_Models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HRMS_Columns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ColumnName = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    HRMS_ConfigurationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HRMS_Columns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HRMS_Columns_HRMS_Configuration_Models_HRMS_ConfigurationId",
                        column: x => x.HRMS_ConfigurationId,
                        principalTable: "HRMS_Configuration_Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "OPERA_Columns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ColumnName = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    StartPOS = table.Column<int>(type: "INTEGER", nullable: false),
                    EndPOS = table.Column<int>(type: "INTEGER", nullable: false),
                    OPERA_ConfigurationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERA_Columns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OPERA_Columns_OPERA_Configuration_Models_OPERA_ConfigurationId",
                        column: x => x.OPERA_ConfigurationId,
                        principalTable: "OPERA_Configuration_Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SUN_DETAIL_Columns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ColumnName = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    SUN_ConfigurationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUN_DETAIL_Columns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SUN_DETAIL_Columns_SUN_Configuration_Models_SUN_ConfigurationId",
                        column: x => x.SUN_ConfigurationId,
                        principalTable: "SUN_Configuration_Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SUN_HDR_Columns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ColumnName = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    SUN_ConfigurationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUN_HDR_Columns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SUN_HDR_Columns_SUN_Configuration_Models_SUN_ConfigurationId",
                        column: x => x.SUN_ConfigurationId,
                        principalTable: "SUN_Configuration_Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HRMS_Columns_HRMS_ConfigurationId",
                table: "HRMS_Columns",
                column: "HRMS_ConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_OPERA_Columns_OPERA_ConfigurationId",
                table: "OPERA_Columns",
                column: "OPERA_ConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_SUN_DETAIL_Columns_SUN_ConfigurationId",
                table: "SUN_DETAIL_Columns",
                column: "SUN_ConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_SUN_HDR_Columns_SUN_ConfigurationId",
                table: "SUN_HDR_Columns",
                column: "SUN_ConfigurationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HRMS_Columns");

            migrationBuilder.DropTable(
                name: "HRMS_DETAIL_Models");

            migrationBuilder.DropTable(
                name: "HRMS_HDR_Models");

            migrationBuilder.DropTable(
                name: "OPERA_Columns");

            migrationBuilder.DropTable(
                name: "OPERA_DETAIL_Models");

            migrationBuilder.DropTable(
                name: "OPERA_HDR_Models");

            migrationBuilder.DropTable(
                name: "SUN_DETAIL_Columns");

            migrationBuilder.DropTable(
                name: "SUN_HDR_Columns");

            migrationBuilder.DropTable(
                name: "HRMS_Configuration_Models");

            migrationBuilder.DropTable(
                name: "OPERA_Configuration_Models");

            migrationBuilder.DropTable(
                name: "SUN_Configuration_Models");
        }
    }
}
