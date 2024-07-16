using Microsoft.EntityFrameworkCore.Migrations;

namespace YksProject.DataAccessLayer.Migrations
{
    public partial class DerslerTableChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DersKodu",
                table: "Dersler");

            migrationBuilder.DropColumn(
                name: "DersSoruSayisi",
                table: "Dersler");

            migrationBuilder.DropColumn(
                name: "DersiEkleyenKurumID",
                table: "Dersler");

            migrationBuilder.DropColumn(
                name: "DersiKurumMuEkledi",
                table: "Dersler");

            migrationBuilder.RenameColumn(
                name: "IlgiliSinavTipiID",
                table: "Dersler",
                newName: "DersBolumID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DersBolumID",
                table: "Dersler",
                newName: "IlgiliSinavTipiID");

            migrationBuilder.AddColumn<string>(
                name: "DersKodu",
                table: "Dersler",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DersSoruSayisi",
                table: "Dersler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DersiEkleyenKurumID",
                table: "Dersler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "DersiKurumMuEkledi",
                table: "Dersler",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
