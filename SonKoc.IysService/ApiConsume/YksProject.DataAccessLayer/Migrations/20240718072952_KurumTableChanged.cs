using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YksProject.DataAccessLayer.Migrations
{
    public partial class KurumTableChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KurumAbonelikBasTarihi",
                table: "Kurum");

            migrationBuilder.DropColumn(
                name: "KurumAbonelikBitisTarihi",
                table: "Kurum");

            migrationBuilder.RenameColumn(
                name: "KurumTipi",
                table: "Kurum",
                newName: "KurumTelNo");

            migrationBuilder.RenameColumn(
                name: "KurumSahibiID",
                table: "Kurum",
                newName: "KurumSahibiTelNo");

            migrationBuilder.RenameColumn(
                name: "KurumAbonelikTipi",
                table: "Kurum",
                newName: "KurumOgrenciSayisi");

            migrationBuilder.RenameColumn(
                name: "KurumAbonelikOgrenciSayisi",
                table: "Kurum",
                newName: "KurumMaxOgrenciLimiti");

            migrationBuilder.AddColumn<string>(
                name: "KurumEmail",
                table: "Kurum",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KurumInstaKullaniciAdi",
                table: "Kurum",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KurumPassword",
                table: "Kurum",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KurumSahibiAdi",
                table: "Kurum",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KurumSahibiEmail",
                table: "Kurum",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KurumWebSiteUrl",
                table: "Kurum",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UserSonCikisTarihi",
                table: "Kisi",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UserSonGirisTarihi",
                table: "Kisi",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserToplamGirisSayisi",
                table: "Kisi",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KurumEmail",
                table: "Kurum");

            migrationBuilder.DropColumn(
                name: "KurumInstaKullaniciAdi",
                table: "Kurum");

            migrationBuilder.DropColumn(
                name: "KurumPassword",
                table: "Kurum");

            migrationBuilder.DropColumn(
                name: "KurumSahibiAdi",
                table: "Kurum");

            migrationBuilder.DropColumn(
                name: "KurumSahibiEmail",
                table: "Kurum");

            migrationBuilder.DropColumn(
                name: "KurumWebSiteUrl",
                table: "Kurum");

            migrationBuilder.DropColumn(
                name: "UserSonCikisTarihi",
                table: "Kisi");

            migrationBuilder.DropColumn(
                name: "UserSonGirisTarihi",
                table: "Kisi");

            migrationBuilder.DropColumn(
                name: "UserToplamGirisSayisi",
                table: "Kisi");

            migrationBuilder.RenameColumn(
                name: "KurumTelNo",
                table: "Kurum",
                newName: "KurumTipi");

            migrationBuilder.RenameColumn(
                name: "KurumSahibiTelNo",
                table: "Kurum",
                newName: "KurumSahibiID");

            migrationBuilder.RenameColumn(
                name: "KurumOgrenciSayisi",
                table: "Kurum",
                newName: "KurumAbonelikTipi");

            migrationBuilder.RenameColumn(
                name: "KurumMaxOgrenciLimiti",
                table: "Kurum",
                newName: "KurumAbonelikOgrenciSayisi");

            migrationBuilder.AddColumn<DateTime>(
                name: "KurumAbonelikBasTarihi",
                table: "Kurum",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "KurumAbonelikBitisTarihi",
                table: "Kurum",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
