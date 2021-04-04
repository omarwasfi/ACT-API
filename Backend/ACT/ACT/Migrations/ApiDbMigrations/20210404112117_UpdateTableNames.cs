using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACT.Migrations.ApiDbMigrations
{
    public partial class UpdateTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HRMS_Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConnectionsString = table.Column<string>(type: "TEXT", nullable: false),
                    CycleTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HRMS_Configurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HRMS_REPORT_SUN_DETAILS",
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
                    table.PrimaryKey("PK_HRMS_REPORT_SUN_DETAILS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HRMS_REPORT_SUN_HDRS",
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
                    table.PrimaryKey("PK_HRMS_REPORT_SUN_HDRS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OPERA_Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilePath = table.Column<string>(type: "TEXT", nullable: false),
                    CycleTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPERA_Configurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OPERA_REPORT_SUN_DETAILS",
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
                    table.PrimaryKey("PK_OPERA_REPORT_SUN_DETAILS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OPERA_REPORT_SUN_HDRS",
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
                    table.PrimaryKey("PK_OPERA_REPORT_SUN_HDRS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SUN_Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConnectionsString = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUN_Configurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HRMS_REPORT_Columns",
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
                    table.PrimaryKey("PK_HRMS_REPORT_Columns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HRMS_REPORT_Columns_HRMS_Configurations_HRMS_ConfigurationId",
                        column: x => x.HRMS_ConfigurationId,
                        principalTable: "HRMS_Configurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "OPERA_REPORT_Columns",
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
                    table.PrimaryKey("PK_OPERA_REPORT_Columns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OPERA_REPORT_Columns_OPERA_Configurations_OPERA_ConfigurationId",
                        column: x => x.OPERA_ConfigurationId,
                        principalTable: "OPERA_Configurations",
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
                        name: "FK_SUN_DETAIL_Columns_SUN_Configurations_SUN_ConfigurationId",
                        column: x => x.SUN_ConfigurationId,
                        principalTable: "SUN_Configurations",
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
                        name: "FK_SUN_HDR_Columns_SUN_Configurations_SUN_ConfigurationId",
                        column: x => x.SUN_ConfigurationId,
                        principalTable: "SUN_Configurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HRMS_REPORT_Columns_HRMS_ConfigurationId",
                table: "HRMS_REPORT_Columns",
                column: "HRMS_ConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_OPERA_REPORT_Columns_OPERA_ConfigurationId",
                table: "OPERA_REPORT_Columns",
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
                name: "HRMS_REPORT_Columns");

            migrationBuilder.DropTable(
                name: "HRMS_REPORT_SUN_DETAILS");

            migrationBuilder.DropTable(
                name: "HRMS_REPORT_SUN_HDRS");

            migrationBuilder.DropTable(
                name: "OPERA_REPORT_Columns");

            migrationBuilder.DropTable(
                name: "OPERA_REPORT_SUN_DETAILS");

            migrationBuilder.DropTable(
                name: "OPERA_REPORT_SUN_HDRS");

            migrationBuilder.DropTable(
                name: "SUN_DETAIL_Columns");

            migrationBuilder.DropTable(
                name: "SUN_HDR_Columns");

            migrationBuilder.DropTable(
                name: "HRMS_Configurations");

            migrationBuilder.DropTable(
                name: "OPERA_Configurations");

            migrationBuilder.DropTable(
                name: "SUN_Configurations");
        }
    }
}
