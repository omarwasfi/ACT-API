using Microsoft.EntityFrameworkCore.Migrations;

namespace ACT.Migrations.ApiDbMigrations
{
    public partial class SupportSavingColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "SUN_Columns",
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
                    table.PrimaryKey("PK_SUN_Columns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SUN_Columns_SUN_Configuration_Models_SUN_ConfigurationId",
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
                name: "IX_SUN_Columns_SUN_ConfigurationId",
                table: "SUN_Columns",
                column: "SUN_ConfigurationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HRMS_Columns");

            migrationBuilder.DropTable(
                name: "OPERA_Columns");

            migrationBuilder.DropTable(
                name: "SUN_Columns");
        }
    }
}
