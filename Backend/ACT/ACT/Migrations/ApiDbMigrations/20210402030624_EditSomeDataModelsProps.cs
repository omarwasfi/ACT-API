using Microsoft.EntityFrameworkCore.Migrations;

namespace ACT.Migrations.ApiDbMigrations
{
    public partial class EditSomeDataModelsProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MapWithHRMS",
                table: "OPERA_HDR_Models",
                newName: "MapWithOPERA");

            migrationBuilder.RenameColumn(
                name: "MapWithHRMS",
                table: "OPERA_DETAIL_Models",
                newName: "MapWithOPERA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MapWithOPERA",
                table: "OPERA_HDR_Models",
                newName: "MapWithHRMS");

            migrationBuilder.RenameColumn(
                name: "MapWithOPERA",
                table: "OPERA_DETAIL_Models",
                newName: "MapWithHRMS");
        }
    }
}
