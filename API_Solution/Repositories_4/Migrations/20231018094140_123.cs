using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories_4.Migrations
{
    public partial class _123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_District_Province_provinceID",
                table: "District");

            migrationBuilder.DropForeignKey(
                name: "FK_Ward_District_districtID",
                table: "Ward");

            migrationBuilder.RenameColumn(
                name: "wardName",
                table: "Ward",
                newName: "WardName");

            migrationBuilder.RenameColumn(
                name: "wardDescription",
                table: "Ward",
                newName: "WardDescription");

            migrationBuilder.RenameColumn(
                name: "districtID",
                table: "Ward",
                newName: "DistrictID");

            migrationBuilder.RenameColumn(
                name: "wardID",
                table: "Ward",
                newName: "WardID");

            migrationBuilder.RenameIndex(
                name: "IX_Ward_districtID",
                table: "Ward",
                newName: "IX_Ward_DistrictID");

            migrationBuilder.RenameColumn(
                name: "provinceName",
                table: "Province",
                newName: "ProvinceName");

            migrationBuilder.RenameColumn(
                name: "provinceDescription",
                table: "Province",
                newName: "ProvinceDescription");

            migrationBuilder.RenameColumn(
                name: "provinceID",
                table: "Province",
                newName: "ProvinceID");

            migrationBuilder.RenameColumn(
                name: "provinceID",
                table: "District",
                newName: "ProvinceID");

            migrationBuilder.RenameColumn(
                name: "districtName",
                table: "District",
                newName: "DistrictName");

            migrationBuilder.RenameColumn(
                name: "districtDescripton",
                table: "District",
                newName: "DistrictDescripton");

            migrationBuilder.RenameColumn(
                name: "districtID",
                table: "District",
                newName: "DistrictID");

            migrationBuilder.RenameIndex(
                name: "IX_District_provinceID",
                table: "District",
                newName: "IX_District_ProvinceID");

            migrationBuilder.AddColumn<int>(
                name: "DrovinceID",
                table: "District",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_District_Province_ProvinceID",
                table: "District",
                column: "ProvinceID",
                principalTable: "Province",
                principalColumn: "ProvinceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ward_District_DistrictID",
                table: "Ward",
                column: "DistrictID",
                principalTable: "District",
                principalColumn: "DistrictID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_District_Province_ProvinceID",
                table: "District");

            migrationBuilder.DropForeignKey(
                name: "FK_Ward_District_DistrictID",
                table: "Ward");

            migrationBuilder.DropColumn(
                name: "DrovinceID",
                table: "District");

            migrationBuilder.RenameColumn(
                name: "WardName",
                table: "Ward",
                newName: "wardName");

            migrationBuilder.RenameColumn(
                name: "WardDescription",
                table: "Ward",
                newName: "wardDescription");

            migrationBuilder.RenameColumn(
                name: "DistrictID",
                table: "Ward",
                newName: "districtID");

            migrationBuilder.RenameColumn(
                name: "WardID",
                table: "Ward",
                newName: "wardID");

            migrationBuilder.RenameIndex(
                name: "IX_Ward_DistrictID",
                table: "Ward",
                newName: "IX_Ward_districtID");

            migrationBuilder.RenameColumn(
                name: "ProvinceName",
                table: "Province",
                newName: "provinceName");

            migrationBuilder.RenameColumn(
                name: "ProvinceDescription",
                table: "Province",
                newName: "provinceDescription");

            migrationBuilder.RenameColumn(
                name: "ProvinceID",
                table: "Province",
                newName: "provinceID");

            migrationBuilder.RenameColumn(
                name: "ProvinceID",
                table: "District",
                newName: "provinceID");

            migrationBuilder.RenameColumn(
                name: "DistrictName",
                table: "District",
                newName: "districtName");

            migrationBuilder.RenameColumn(
                name: "DistrictDescripton",
                table: "District",
                newName: "districtDescripton");

            migrationBuilder.RenameColumn(
                name: "DistrictID",
                table: "District",
                newName: "districtID");

            migrationBuilder.RenameIndex(
                name: "IX_District_ProvinceID",
                table: "District",
                newName: "IX_District_provinceID");

            migrationBuilder.AddForeignKey(
                name: "FK_District_Province_provinceID",
                table: "District",
                column: "provinceID",
                principalTable: "Province",
                principalColumn: "provinceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ward_District_districtID",
                table: "Ward",
                column: "districtID",
                principalTable: "District",
                principalColumn: "districtID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
