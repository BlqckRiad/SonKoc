using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YksProject.DataAccessLayer.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AbonePaketAciklamasi",
                table: "BaseModel");

            migrationBuilder.DropColumn(
                name: "AbonePaketAdi",
                table: "BaseModel");

            migrationBuilder.DropColumn(
                name: "AboneTipi",
                table: "BaseModel");

            migrationBuilder.DropColumn(
                name: "AbonelikUcreti",
                table: "BaseModel");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseModel");

            migrationBuilder.DropColumn(
                name: "GirenKisiID",
                table: "BaseModel");

            migrationBuilder.DropColumn(
                name: "GirilenSinavinTipi",
                table: "BaseModel");

            migrationBuilder.DropColumn(
                name: "KisiAboneMi",
                table: "BaseModel");

            migrationBuilder.DropColumn(
                name: "KisiAbonelikTarihi",
                table: "BaseModel");

            migrationBuilder.DropColumn(
                name: "KisiAdi",
                table: "BaseModel");

            migrationBuilder.DropColumn(
                name: "KisiGirdigiSinavlar",
                table: "BaseModel");

            migrationBuilder.DropColumn(
                name: "KisiImageUrl",
                table: "BaseModel");

            migrationBuilder.DropColumn(
                name: "KisiObpDegeri",
                table: "BaseModel");

            migrationBuilder.DropColumn(
                name: "KisiSonGirisTarihi",
                table: "BaseModel");

            migrationBuilder.DropColumn(
                name: "KisiSoyAdi",
                table: "BaseModel");

            migrationBuilder.DropColumn(
                name: "KisiYasi",
                table: "BaseModel");

            migrationBuilder.DropColumn(
                name: "ReferansAciklamasi",
                table: "BaseModel");

            migrationBuilder.DropColumn(
                name: "ReferansAdi",
                table: "BaseModel");

            migrationBuilder.DropColumn(
                name: "ReferansImage",
                table: "BaseModel");

            migrationBuilder.DropColumn(
                name: "ReferansPuani",
                table: "BaseModel");

            migrationBuilder.DropColumn(
                name: "SinavAdi",
                table: "BaseModel");

            migrationBuilder.DropColumn(
                name: "SinavBitisTarihi",
                table: "BaseModel");

            migrationBuilder.DropColumn(
                name: "SinavGirisTarihi",
                table: "BaseModel");

            migrationBuilder.DropColumn(
                name: "SinavKodu",
                table: "BaseModel");

            migrationBuilder.DropColumn(
                name: "SinavSonucu",
                table: "BaseModel");

            migrationBuilder.DropColumn(
                name: "SinavSüresi",
                table: "BaseModel");

            migrationBuilder.CreateTable(
                name: "Abonelik",
                columns: table => new
                {
                    TabloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbonePaketAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbonePaketAciklamasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbonelikUcreti = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonelik", x => x.TabloID);
                });

            migrationBuilder.CreateTable(
                name: "GirilenSinav",
                columns: table => new
                {
                    TabloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GirilenSinavinTipi = table.Column<int>(type: "int", nullable: false),
                    GirenKisiID = table.Column<int>(type: "int", nullable: false),
                    SinavGirisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SinavBitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SinavSonucu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GirilenSinav", x => x.TabloID);
                });

            migrationBuilder.CreateTable(
                name: "Kisi",
                columns: table => new
                {
                    TabloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KisiAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KisiSoyAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KisiYasi = table.Column<int>(type: "int", nullable: false),
                    KisiObpDegeri = table.Column<int>(type: "int", nullable: false),
                    KisiGirdigiSinavlar = table.Column<int>(type: "int", nullable: false),
                    KisiImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KisiAboneMi = table.Column<int>(type: "int", nullable: false),
                    AboneTipi = table.Column<int>(type: "int", nullable: false),
                    KisiAbonelikTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KisiSonGirisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisi", x => x.TabloID);
                });

            migrationBuilder.CreateTable(
                name: "Referanslarimiz",
                columns: table => new
                {
                    TabloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReferansAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferansAciklamasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferansImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferansPuani = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referanslarimiz", x => x.TabloID);
                });

            migrationBuilder.CreateTable(
                name: "Sinav",
                columns: table => new
                {
                    TabloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinavAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SinavKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SinavSüresi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sinav", x => x.TabloID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abonelik");

            migrationBuilder.DropTable(
                name: "GirilenSinav");

            migrationBuilder.DropTable(
                name: "Kisi");

            migrationBuilder.DropTable(
                name: "Referanslarimiz");

            migrationBuilder.DropTable(
                name: "Sinav");

            migrationBuilder.AddColumn<string>(
                name: "AbonePaketAciklamasi",
                table: "BaseModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AbonePaketAdi",
                table: "BaseModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AboneTipi",
                table: "BaseModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AbonelikUcreti",
                table: "BaseModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GirenKisiID",
                table: "BaseModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GirilenSinavinTipi",
                table: "BaseModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KisiAboneMi",
                table: "BaseModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "KisiAbonelikTarihi",
                table: "BaseModel",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KisiAdi",
                table: "BaseModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KisiGirdigiSinavlar",
                table: "BaseModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KisiImageUrl",
                table: "BaseModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KisiObpDegeri",
                table: "BaseModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "KisiSonGirisTarihi",
                table: "BaseModel",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KisiSoyAdi",
                table: "BaseModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KisiYasi",
                table: "BaseModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferansAciklamasi",
                table: "BaseModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferansAdi",
                table: "BaseModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferansImage",
                table: "BaseModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferansPuani",
                table: "BaseModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SinavAdi",
                table: "BaseModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SinavBitisTarihi",
                table: "BaseModel",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SinavGirisTarihi",
                table: "BaseModel",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SinavKodu",
                table: "BaseModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SinavSonucu",
                table: "BaseModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SinavSüresi",
                table: "BaseModel",
                type: "int",
                nullable: true);
        }
    }
}
