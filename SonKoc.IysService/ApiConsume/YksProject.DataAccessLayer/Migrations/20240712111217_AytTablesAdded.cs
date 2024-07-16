using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YksProject.DataAccessLayer.Migrations
{
    public partial class AytTablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AytEaGirisTablosu",
                columns: table => new
                {
                    TabloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinavAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GirilenSinavID = table.Column<int>(type: "int", nullable: false),
                    GirenKisiID = table.Column<int>(type: "int", nullable: false),
                    BaslangicZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AytMatDogruSayisi = table.Column<int>(type: "int", nullable: false),
                    AytMatYanlisSayisi = table.Column<int>(type: "int", nullable: false),
                    AytMatNetSayisi = table.Column<double>(type: "float", nullable: false),
                    AytEdebiyatDogruSayisi = table.Column<int>(type: "int", nullable: false),
                    AytEdebiyatYanlisSayisi = table.Column<int>(type: "int", nullable: false),
                    AytEdebiyatNetSayisi = table.Column<double>(type: "float", nullable: false),
                    AytTarih1DogruSayisi = table.Column<int>(type: "int", nullable: false),
                    AytTarih1YanlisSayisi = table.Column<int>(type: "int", nullable: false),
                    AytTarih1NetSayisi = table.Column<double>(type: "float", nullable: false),
                    AytCografya1DogruSayisi = table.Column<int>(type: "int", nullable: false),
                    AytCografya1YanlisSayisi = table.Column<int>(type: "int", nullable: false),
                    AytCografya1NetSayisi = table.Column<double>(type: "float", nullable: false),
                    AytMatToplamDakika = table.Column<int>(type: "int", nullable: false),
                    AytEdebiyatToplamDakika = table.Column<int>(type: "int", nullable: false),
                    AytTarih1ToplamDakika = table.Column<int>(type: "int", nullable: false),
                    AytCografya1ToplamDakika = table.Column<int>(type: "int", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OlusturanKisiID = table.Column<int>(type: "int", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncelleyenKisiID = table.Column<int>(type: "int", nullable: false),
                    SilinmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SilenKisiID = table.Column<int>(type: "int", nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AytEaGirisTablosu", x => x.TabloID);
                });

            migrationBuilder.CreateTable(
                name: "AytSayGirisTablosu",
                columns: table => new
                {
                    TabloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinavAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GirilenSinavID = table.Column<int>(type: "int", nullable: false),
                    GirenKisiID = table.Column<int>(type: "int", nullable: false),
                    BaslangicZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AytMatDogruSayisi = table.Column<int>(type: "int", nullable: false),
                    AytMatYanlisSayisi = table.Column<int>(type: "int", nullable: false),
                    AytMatNetSayisi = table.Column<double>(type: "float", nullable: false),
                    AytFizikDogruSayisi = table.Column<int>(type: "int", nullable: false),
                    AytFizikYanlisSayisi = table.Column<int>(type: "int", nullable: false),
                    AytFizikNetSayisi = table.Column<double>(type: "float", nullable: false),
                    AytKimyaDogruSayisi = table.Column<int>(type: "int", nullable: false),
                    AytKimyaYanlisSayisi = table.Column<int>(type: "int", nullable: false),
                    AytKimyaNetSayisi = table.Column<double>(type: "float", nullable: false),
                    AytBiyolojiDogruSayisi = table.Column<int>(type: "int", nullable: false),
                    AytBiyolojiYanlisSayisi = table.Column<int>(type: "int", nullable: false),
                    AytBiyolojiNetSayisi = table.Column<double>(type: "float", nullable: false),
                    AytMatToplamDakika = table.Column<int>(type: "int", nullable: false),
                    AytFizikToplamDakika = table.Column<int>(type: "int", nullable: false),
                    AytKimyaToplamDakika = table.Column<int>(type: "int", nullable: false),
                    AytBiyolojiToplamDakika = table.Column<int>(type: "int", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OlusturanKisiID = table.Column<int>(type: "int", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncelleyenKisiID = table.Column<int>(type: "int", nullable: false),
                    SilinmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SilenKisiID = table.Column<int>(type: "int", nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AytSayGirisTablosu", x => x.TabloID);
                });

            migrationBuilder.CreateTable(
                name: "AytSozelGirisTablosu",
                columns: table => new
                {
                    TabloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinavAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GirilenSinavID = table.Column<int>(type: "int", nullable: false),
                    GirenKisiID = table.Column<int>(type: "int", nullable: false),
                    BaslangicZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AytEdebiyatDogruSayisi = table.Column<int>(type: "int", nullable: false),
                    AytEdebiyatYanlisSayisi = table.Column<int>(type: "int", nullable: false),
                    AytEdebiyatNetSayisi = table.Column<double>(type: "float", nullable: false),
                    AytTarih1DogruSayisi = table.Column<int>(type: "int", nullable: false),
                    AytTarih1YanlisSayisi = table.Column<int>(type: "int", nullable: false),
                    AytTarih1NetSayisi = table.Column<double>(type: "float", nullable: false),
                    AytCografya1DogruSayisi = table.Column<int>(type: "int", nullable: false),
                    AytCografya1YanlisSayisi = table.Column<int>(type: "int", nullable: false),
                    AytCografya1NetSayisi = table.Column<double>(type: "float", nullable: false),
                    AytTarih2DogruSayisi = table.Column<int>(type: "int", nullable: false),
                    AytTarih2YanlisSayisi = table.Column<int>(type: "int", nullable: false),
                    AytTarih2NetSayisi = table.Column<double>(type: "float", nullable: false),
                    AytCografya2DogruSayisi = table.Column<int>(type: "int", nullable: false),
                    AytCografya2YanlisSayisi = table.Column<int>(type: "int", nullable: false),
                    AytCografya2NetSayisi = table.Column<double>(type: "float", nullable: false),
                    AytFelsefeDogruSayisi = table.Column<int>(type: "int", nullable: false),
                    AytFelsefeYanlisSayisi = table.Column<int>(type: "int", nullable: false),
                    AytFelsefeNetSayisi = table.Column<double>(type: "float", nullable: false),
                    AytDinDogruSayisi = table.Column<int>(type: "int", nullable: false),
                    AytDinYanlisSayisi = table.Column<int>(type: "int", nullable: false),
                    AytDinNetSayisi = table.Column<double>(type: "float", nullable: false),
                    AytEdebiyatToplamDakika = table.Column<int>(type: "int", nullable: false),
                    AytTarih1ToplamDakika = table.Column<int>(type: "int", nullable: false),
                    AytCografya1ToplamDakika = table.Column<int>(type: "int", nullable: false),
                    AytTarih2ToplamDakika = table.Column<int>(type: "int", nullable: false),
                    AytCografya2ToplamDakika = table.Column<int>(type: "int", nullable: false),
                    AytFelsefeToplamDakika = table.Column<int>(type: "int", nullable: false),
                    AytDinToplamDakika = table.Column<int>(type: "int", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OlusturanKisiID = table.Column<int>(type: "int", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncelleyenKisiID = table.Column<int>(type: "int", nullable: false),
                    SilinmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SilenKisiID = table.Column<int>(type: "int", nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AytSozelGirisTablosu", x => x.TabloID);
                });

            migrationBuilder.CreateTable(
                name: "AytYDGirisTablosu",
                columns: table => new
                {
                    TabloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinavAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GirilenSinavID = table.Column<int>(type: "int", nullable: false),
                    GirenKisiID = table.Column<int>(type: "int", nullable: false),
                    BaslangicZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AytDilDogruSayisi = table.Column<int>(type: "int", nullable: false),
                    AytDilYanlisSayisi = table.Column<int>(type: "int", nullable: false),
                    AytDilNetSayisi = table.Column<double>(type: "float", nullable: false),
                    AytDilToplamDakika = table.Column<int>(type: "int", nullable: false),
                    BitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OlusturanKisiID = table.Column<int>(type: "int", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncelleyenKisiID = table.Column<int>(type: "int", nullable: false),
                    SilinmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SilenKisiID = table.Column<int>(type: "int", nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AytYDGirisTablosu", x => x.TabloID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AytEaGirisTablosu");

            migrationBuilder.DropTable(
                name: "AytSayGirisTablosu");

            migrationBuilder.DropTable(
                name: "AytSozelGirisTablosu");

            migrationBuilder.DropTable(
                name: "AytYDGirisTablosu");
        }
    }
}
