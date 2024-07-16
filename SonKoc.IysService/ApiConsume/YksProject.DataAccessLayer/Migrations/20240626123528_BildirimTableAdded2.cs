using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YksProject.DataAccessLayer.Migrations
{
    public partial class BildirimTableAdded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bildirimler",
                columns: table => new
                {
                    TabloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GonderenKisiID = table.Column<int>(type: "int", nullable: false),
                    AliciKisiID = table.Column<int>(type: "int", nullable: false),
                    BildirimBasligi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BildirimAciklamasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BildirimAliciOkuduMu = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_Bildirimler", x => x.TabloID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bildirimler");
        }
    }
}
