using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Repositories_4.Migrations
{
    public partial class dd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    provinceID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    provinceName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    provinceDescription = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.provinceID);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    districtID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    districtName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    districtDescripton = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    provinceID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.districtID);
                    table.ForeignKey(
                        name: "FK_District_Province_provinceID",
                        column: x => x.provinceID,
                        principalTable: "Province",
                        principalColumn: "provinceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ward",
                columns: table => new
                {
                    wardID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    wardName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    wardDescription = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    districtID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ward", x => x.wardID);
                    table.ForeignKey(
                        name: "FK_Ward_District_districtID",
                        column: x => x.districtID,
                        principalTable: "District",
                        principalColumn: "districtID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_District_provinceID",
                table: "District",
                column: "provinceID");

            migrationBuilder.CreateIndex(
                name: "IX_Ward_districtID",
                table: "Ward",
                column: "districtID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ward");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "Province");
        }
    }
}
