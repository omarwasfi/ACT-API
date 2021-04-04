using Microsoft.EntityFrameworkCore.Migrations;

namespace ACT.Migrations.ApiDbAccess
{
    public partial class addNumberOfLinesToIgnoreToOperaConf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfLinesToIgnore",
                table: "OPERA_Configurations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfLinesToIgnore",
                table: "OPERA_Configurations");
        }
    }
}
