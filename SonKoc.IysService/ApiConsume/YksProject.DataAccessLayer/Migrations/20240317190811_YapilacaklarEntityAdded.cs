using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YksProject.DataAccessLayer.Migrations
{
    public partial class YapilacaklarEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Yapilacaklar",
                columns: table => new
                {
                    TabloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KisiID = table.Column<int>(type: "int", nullable: false),
                    YapilacakGorevAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YapilacakGorevAciklamasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YapilacakGorevIkon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YapilacakGorevGun = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YapilacakGorevGunNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YapildiMi = table.Column<int>(type: "int", nullable: false),
                    GorevEklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GorevYapilmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yapilacaklar", x => x.TabloID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Yapilacaklar");
        }
    }
}
