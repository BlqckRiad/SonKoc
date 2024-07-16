using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YksProject.DataAccessLayer.Migrations
{
    public partial class HomePostTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomePost",
                columns: table => new
                {
                    TabloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostAciklamasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostMedyaUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostMedyaID = table.Column<int>(type: "int", nullable: false),
                    PostYayindaMi = table.Column<bool>(type: "bit", nullable: false),
                    PostSahibi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostGorulmeSayisi = table.Column<int>(type: "int", nullable: false),
                    PostTiklanmaSayisi = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_HomePost", x => x.TabloID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomePost");
        }
    }
}
