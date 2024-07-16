using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YksProject.DataAccessLayer.Migrations
{
    public partial class TytSinavTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SinavTipiID",
                table: "Sinav",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SinavTipleri",
                columns: table => new
                {
                    TabloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinavTipiID = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_SinavTipleri", x => x.TabloID);
                });

            migrationBuilder.CreateTable(
                name: "TytSinavGirisTablosu",
                columns: table => new
                {
                    TabloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinavAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GirilenSinavID = table.Column<int>(type: "int", nullable: false),
                    GirenKisiID = table.Column<int>(type: "int", nullable: false),
                    BaslangicZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TytTurkceDogruSayisi = table.Column<int>(type: "int", nullable: false),
                    TytTurkceYanlisSayisi = table.Column<int>(type: "int", nullable: false),
                    TytTurkceNetSayisi = table.Column<int>(type: "int", nullable: false),
                    TytMatematikDogruSayisi = table.Column<int>(type: "int", nullable: false),
                    TytMatematikYanlisSayisi = table.Column<int>(type: "int", nullable: false),
                    TytMatematikNetSayisi = table.Column<int>(type: "int", nullable: false),
                    TytFenDogruSayisi = table.Column<int>(type: "int", nullable: false),
                    TytFenYanlisSayisi = table.Column<int>(type: "int", nullable: false),
                    TytFenNetSayisi = table.Column<int>(type: "int", nullable: false),
                    TytSosyalDogruSayisi = table.Column<int>(type: "int", nullable: false),
                    TytSosyalYanlisSayisi = table.Column<int>(type: "int", nullable: false),
                    TytSosyalNetSayisi = table.Column<int>(type: "int", nullable: false),
                    TytTurkceToplamDakika = table.Column<int>(type: "int", nullable: false),
                    TytFenToplamDakika = table.Column<int>(type: "int", nullable: false),
                    TytMatematikToplamDakika = table.Column<int>(type: "int", nullable: false),
                    TytSosyalToplamDakika = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_TytSinavGirisTablosu", x => x.TabloID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SinavTipleri");

            migrationBuilder.DropTable(
                name: "TytSinavGirisTablosu");

            migrationBuilder.DropColumn(
                name: "SinavTipiID",
                table: "Sinav");
        }
    }
}
