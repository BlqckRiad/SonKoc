using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YksProject.DataAccessLayer.Migrations
{
    public partial class UyelikPackageAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaketUyeTipleri",
                columns: table => new
                {
                    TabloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UyeTipiAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UyeTipiAciklamasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_PaketUyeTipleri", x => x.TabloID);
                });

            migrationBuilder.CreateTable(
                name: "UyelikPaketleri",
                columns: table => new
                {
                    TabloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaketAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaketAciklamasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaketImageID = table.Column<int>(type: "int", nullable: false),
                    PaketImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaketUcreti = table.Column<int>(type: "int", nullable: false),
                    PaketIndirimOrani = table.Column<int>(type: "int", nullable: false),
                    PaketUyeTipiID = table.Column<int>(type: "int", nullable: false),
                    PaketUyeSayısı = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_UyelikPaketleri", x => x.TabloID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaketUyeTipleri");

            migrationBuilder.DropTable(
                name: "UyelikPaketleri");
        }
    }
}
