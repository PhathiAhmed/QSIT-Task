using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QSIT.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Map_Sub_Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MapTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Map_Sub_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Map_Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Map_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Raduis = table.Column<double>(type: "float", nullable: true),
                    GeoFencing = table.Column<bool>(type: "bit", nullable: true),
                    Location = table.Column<double>(type: "float", nullable: true),
                    Time = table.Column<int>(type: "int", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    MapTypeId = table.Column<int>(type: "int", nullable: false),
                    MapSubTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maps_Map_Sub_Types_MapSubTypeId",
                        column: x => x.MapSubTypeId,
                        principalTable: "Map_Sub_Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction, onUpdate: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maps_Map_Types_MapTypeId",
                        column: x => x.MapTypeId,
                        principalTable: "Map_Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction, onUpdate: ReferentialAction.Cascade) ;
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maps_MapSubTypeId",
                table: "Maps",
                column: "MapSubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Maps_MapTypeId",
                table: "Maps",
                column: "MapTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maps");

            migrationBuilder.DropTable(
                name: "Map_Sub_Types");

            migrationBuilder.DropTable(
                name: "Map_Types");
        }
    }
}
