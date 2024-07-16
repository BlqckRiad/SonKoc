using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YksProject.DataAccessLayer.Migrations
{
    public partial class TablesChanncedAnyOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KurumAbonelikTarihi",
                table: "Kurum",
                newName: "KurumAbonelikBitisTarihi");

            migrationBuilder.AddColumn<int>(
                name: "SinaviEkleyenKurumID",
                table: "Sinav",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "KurumAbonelikBasTarihi",
                table: "Kurum",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "KurumAbonelikOgrenciSayisi",
                table: "Kurum",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KisiBolumID",
                table: "Kisi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "KisiKurumSahibiMi",
                table: "Kisi",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "GirilenSinavID",
                table: "GirilenSinav",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SinaviEkleyenKurumID",
                table: "Sinav");

            migrationBuilder.DropColumn(
                name: "KurumAbonelikBasTarihi",
                table: "Kurum");

            migrationBuilder.DropColumn(
                name: "KurumAbonelikOgrenciSayisi",
                table: "Kurum");

            migrationBuilder.DropColumn(
                name: "KisiBolumID",
                table: "Kisi");

            migrationBuilder.DropColumn(
                name: "KisiKurumSahibiMi",
                table: "Kisi");

            migrationBuilder.DropColumn(
                name: "GirilenSinavID",
                table: "GirilenSinav");

            migrationBuilder.DropColumn(
                name: "DersiEkleyenKurumID",
                table: "Dersler");

            migrationBuilder.DropColumn(
                name: "DersiKurumMuEkledi",
                table: "Dersler");

            migrationBuilder.RenameColumn(
                name: "KurumAbonelikBitisTarihi",
                table: "Kurum",
                newName: "KurumAbonelikTarihi");
        }
    }
}
