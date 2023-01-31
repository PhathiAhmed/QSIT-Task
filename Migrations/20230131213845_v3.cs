using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QSIT.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Geo_Fencing",
                table: "Maps",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Geo_Fencing",
                table: "Maps");
        }
    }
}
