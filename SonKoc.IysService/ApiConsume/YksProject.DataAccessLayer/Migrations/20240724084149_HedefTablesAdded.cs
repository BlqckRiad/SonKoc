using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YksProject.DataAccessLayer.Migrations
{
    public partial class HedefTablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AytEaHedef",
                columns: table => new
                {
                    TabloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AytMatDogruHedefi = table.Column<int>(type: "int", nullable: false),
                    AytMatYanlisHedefi = table.Column<int>(type: "int", nullable: false),
                    AytEdebiyatDogruHedefi = table.Column<int>(type: "int", nullable: false),
                    AytEdebiyatYanlisHedefi = table.Column<int>(type: "int", nullable: false),
                    AytTarih1DogruHedefi = table.Column<int>(type: "int", nullable: false),
                    AytTarih1YanlisHedefi = table.Column<int>(type: "int", nullable: false),
                    AytCografya1DogruHedefi = table.Column<int>(type: "int", nullable: false),
                    AytCografya1YanlisHedefi = table.Column<int>(type: "int", nullable: false),
                    HedefToplamNet = table.Column<double>(type: "float", nullable: false),
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
                    table.PrimaryKey("PK_AytEaHedef", x => x.TabloID);
                });

            migrationBuilder.CreateTable(
                name: "AytSayHedef",
                columns: table => new
                {
                    TabloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AytMatDogruHedefi = table.Column<int>(type: "int", nullable: false),
                    AytMatYanlisHedefi = table.Column<int>(type: "int", nullable: false),
                    AytFizikDogruHedefi = table.Column<int>(type: "int", nullable: false),
                    AytFizikYanlisHedefi = table.Column<int>(type: "int", nullable: false),
                    AytKimyaDogruHedefi = table.Column<int>(type: "int", nullable: false),
                    AytKimyaYanlisHedefi = table.Column<int>(type: "int", nullable: false),
                    AytBiyolojiDogruHedefi = table.Column<int>(type: "int", nullable: false),
                    AytBiyolojiYanlisHedefi = table.Column<int>(type: "int", nullable: false),
                    HedefToplamNet = table.Column<double>(type: "float", nullable: false),
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
                    table.PrimaryKey("PK_AytSayHedef", x => x.TabloID);
                });

            migrationBuilder.CreateTable(
                name: "AytSozelHedef",
                columns: table => new
                {
                    TabloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AytMatDogruHedefi = table.Column<int>(type: "int", nullable: false),
                    AytMatYanlisHedefi = table.Column<int>(type: "int", nullable: false),
                    AytEdebiyatDogruHedefi = table.Column<int>(type: "int", nullable: false),
                    AytEdebiyatYanlisHedefi = table.Column<int>(type: "int", nullable: false),
                    AytTarih1DogruHedefi = table.Column<int>(type: "int", nullable: false),
                    AytTarih1YanlisHedefi = table.Column<int>(type: "int", nullable: false),
                    AytCografya1DogruHedefi = table.Column<int>(type: "int", nullable: false),
                    AytCografya1YanlisHedefi = table.Column<int>(type: "int", nullable: false),
                    AytTarih2DogruHedefi = table.Column<int>(type: "int", nullable: false),
                    AytTarih2YanlisHedefi = table.Column<int>(type: "int", nullable: false),
                    AytCografya2DogruHedefi = table.Column<int>(type: "int", nullable: false),
                    AytCografya2YanlisHedefi = table.Column<int>(type: "int", nullable: false),
                    AytDinDogruHedefi = table.Column<int>(type: "int", nullable: false),
                    AytDinYanlisHedefi = table.Column<int>(type: "int", nullable: false),
                    AytFelsefeDogruHedefi = table.Column<int>(type: "int", nullable: false),
                    AytFelsefeYanlisHedefi = table.Column<int>(type: "int", nullable: false),
                    HedefToplamNet = table.Column<double>(type: "float", nullable: false),
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
                    table.PrimaryKey("PK_AytSozelHedef", x => x.TabloID);
                });

            migrationBuilder.CreateTable(
                name: "AytYdHedef",
                columns: table => new
                {
                    TabloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AytYdDogruHedefi = table.Column<int>(type: "int", nullable: false),
                    AytYdYanlisHedefi = table.Column<int>(type: "int", nullable: false),
                    HedefToplamNet = table.Column<double>(type: "float", nullable: false),
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
                    table.PrimaryKey("PK_AytYdHedef", x => x.TabloID);
                });

            migrationBuilder.CreateTable(
                name: "HedefGenelTanimlari",
                columns: table => new
                {
                    TabloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HedefYapanKisiID = table.Column<int>(type: "int", nullable: false),
                    HedefYapanKisiBolumID = table.Column<int>(type: "int", nullable: false),
                    HedefTytID = table.Column<int>(type: "int", nullable: false),
                    HedefAytID = table.Column<int>(type: "int", nullable: false),
                    HedefPuani = table.Column<double>(type: "float", nullable: false),
                    HedefSiralama = table.Column<int>(type: "int", nullable: false),
                    HedefNotu = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_HedefGenelTanimlari", x => x.TabloID);
                });

            migrationBuilder.CreateTable(
                name: "TytHedef",
                columns: table => new
                {
                    TabloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TytMatDogruHedefi = table.Column<int>(type: "int", nullable: false),
                    TytMatYanlisHedefi = table.Column<int>(type: "int", nullable: false),
                    TytFenDogruHedefi = table.Column<int>(type: "int", nullable: false),
                    TytFenYanlisHedefi = table.Column<int>(type: "int", nullable: false),
                    TytTurkceDogruHedefi = table.Column<int>(type: "int", nullable: false),
                    TytTurkceYanlisHedefi = table.Column<int>(type: "int", nullable: false),
                    TytSosyalDogruHedefi = table.Column<int>(type: "int", nullable: false),
                    TytSosyalYanlisHedefi = table.Column<int>(type: "int", nullable: false),
                    HedefToplamNet = table.Column<double>(type: "float", nullable: false),
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
                    table.PrimaryKey("PK_TytHedef", x => x.TabloID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AytEaHedef");

            migrationBuilder.DropTable(
                name: "AytSayHedef");

            migrationBuilder.DropTable(
                name: "AytSozelHedef");

            migrationBuilder.DropTable(
                name: "AytYdHedef");

            migrationBuilder.DropTable(
                name: "HedefGenelTanimlari");

            migrationBuilder.DropTable(
                name: "TytHedef");
        }
    }
}
