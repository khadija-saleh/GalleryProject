using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gallery.Persistance.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gals",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gals", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    fileUBL = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GalImage",
                columns: table => new
                {
                    Galsid = table.Column<int>(type: "int", nullable: false),
                    Imagesid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalImage", x => new { x.Galsid, x.Imagesid });
                    table.ForeignKey(
                        name: "FK_GalImage_Gals_Galsid",
                        column: x => x.Galsid,
                        principalTable: "Gals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GalImage_Images_Imagesid",
                        column: x => x.Imagesid,
                        principalTable: "Images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GalImage_Imagesid",
                table: "GalImage",
                column: "Imagesid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GalImage");

            migrationBuilder.DropTable(
                name: "Gals");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
