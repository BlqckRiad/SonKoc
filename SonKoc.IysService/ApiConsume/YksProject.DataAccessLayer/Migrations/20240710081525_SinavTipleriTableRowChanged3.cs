using Microsoft.EntityFrameworkCore.Migrations;

namespace YksProject.DataAccessLayer.Migrations
{
    public partial class SinavTipleriTableRowChanged3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SinavTipiID",
                table: "SinavTipleri");

            migrationBuilder.AddColumn<string>(
                name: "SinavTipiAdi",
                table: "SinavTipleri",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SinavTipiAdi",
                table: "SinavTipleri");

            migrationBuilder.AddColumn<int>(
                name: "SinavTipiID",
                table: "SinavTipleri",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
