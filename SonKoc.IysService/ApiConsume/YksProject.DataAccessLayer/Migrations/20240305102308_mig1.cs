using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YksProject.DataAccessLayer.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseModel",
                columns: table => new
                {
                    TabloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AktifMi = table.Column<int>(type: "int", nullable: false),
                    AktiflikTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AktifEdenKisiID = table.Column<int>(type: "int", nullable: false),
                    SilindiMi = table.Column<int>(type: "int", nullable: false),
                    SilinmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SilenKisiID = table.Column<int>(type: "int", nullable: false),
                    GuncellendiMi = table.Column<int>(type: "int", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncelleyenKisiID = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbonePaketAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbonePaketAciklamasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbonelikUcreti = table.Column<int>(type: "int", nullable: true),
                    GirilenSinavinTipi = table.Column<int>(type: "int", nullable: true),
                    GirenKisiID = table.Column<int>(type: "int", nullable: true),
                    SinavGirisTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SinavBitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SinavSonucu = table.Column<int>(type: "int", nullable: true),
                    KisiAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KisiSoyAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KisiYasi = table.Column<int>(type: "int", nullable: true),
                    KisiObpDegeri = table.Column<int>(type: "int", nullable: true),
                    KisiGirdigiSinavlar = table.Column<int>(type: "int", nullable: true),
                    KisiImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KisiAboneMi = table.Column<int>(type: "int", nullable: true),
                    AboneTipi = table.Column<int>(type: "int", nullable: true),
                    KisiAbonelikTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KisiSonGirisTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReferansAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferansAciklamasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferansImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferansPuani = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SinavAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SinavKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SinavSüresi = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseModel", x => x.TabloID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseModel");
        }
    }
}
