using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YksProject.DataAccessLayer.Migrations
{
    public partial class RollerTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EkleyenKisiID",
                table: "Yapilacaklar",
                newName: "SilenKisiID");

            migrationBuilder.RenameColumn(
                name: "EklenmeTarihi",
                table: "Yapilacaklar",
                newName: "OlusturulmaTarihi");

            migrationBuilder.RenameColumn(
                name: "EkleyenKisiID",
                table: "Sinav",
                newName: "SilenKisiID");

            migrationBuilder.RenameColumn(
                name: "EklenmeTarihi",
                table: "Sinav",
                newName: "OlusturulmaTarihi");

            migrationBuilder.RenameColumn(
                name: "EkleyenKisiID",
                table: "Referanslarimiz",
                newName: "SilenKisiID");

            migrationBuilder.RenameColumn(
                name: "EklenmeTarihi",
                table: "Referanslarimiz",
                newName: "OlusturulmaTarihi");

            migrationBuilder.RenameColumn(
                name: "EkleyenKisiID",
                table: "MedyaKutuphanesi",
                newName: "SilenKisiID");

            migrationBuilder.RenameColumn(
                name: "EklenmeTarihi",
                table: "MedyaKutuphanesi",
                newName: "OlusturulmaTarihi");

            migrationBuilder.RenameColumn(
                name: "EkleyenKisiID",
                table: "Kurum",
                newName: "SilenKisiID");

            migrationBuilder.RenameColumn(
                name: "EklenmeTarihi",
                table: "Kurum",
                newName: "OlusturulmaTarihi");

            migrationBuilder.RenameColumn(
                name: "KisiSonGirisTarihi",
                table: "Kisi",
                newName: "SilinmeTarihi");

            migrationBuilder.RenameColumn(
                name: "KisiSilindiMi",
                table: "Kisi",
                newName: "SilenKisiID");

            migrationBuilder.RenameColumn(
                name: "KisiKayitTarihi",
                table: "Kisi",
                newName: "OlusturulmaTarihi");

            migrationBuilder.RenameColumn(
                name: "EkleyenKisiID",
                table: "GirilenSinav",
                newName: "SilenKisiID");

            migrationBuilder.RenameColumn(
                name: "EklenmeTarihi",
                table: "GirilenSinav",
                newName: "OlusturulmaTarihi");

            migrationBuilder.RenameColumn(
                name: "EkleyenKisiID",
                table: "Dersler",
                newName: "SilenKisiID");

            migrationBuilder.RenameColumn(
                name: "EklenmeTarihi",
                table: "Dersler",
                newName: "OlusturulmaTarihi");

            migrationBuilder.RenameColumn(
                name: "EkleyenKisiID",
                table: "Bolumler",
                newName: "SilenKisiID");

            migrationBuilder.RenameColumn(
                name: "EklenmeTarihi",
                table: "Bolumler",
                newName: "OlusturulmaTarihi");

            migrationBuilder.RenameColumn(
                name: "EkleyenKisiID",
                table: "Abonelik",
                newName: "SilenKisiID");

            migrationBuilder.RenameColumn(
                name: "EklenmeTarihi",
                table: "Abonelik",
                newName: "OlusturulmaTarihi");

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellenmeTarihi",
                table: "Yapilacaklar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GuncelleyenKisiID",
                table: "Yapilacaklar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OlusturanKisiID",
                table: "Yapilacaklar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellenmeTarihi",
                table: "Sinav",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GuncelleyenKisiID",
                table: "Sinav",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OlusturanKisiID",
                table: "Sinav",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellenmeTarihi",
                table: "Referanslarimiz",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GuncelleyenKisiID",
                table: "Referanslarimiz",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OlusturanKisiID",
                table: "Referanslarimiz",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellenmeTarihi",
                table: "MedyaKutuphanesi",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GuncelleyenKisiID",
                table: "MedyaKutuphanesi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OlusturanKisiID",
                table: "MedyaKutuphanesi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellenmeTarihi",
                table: "Kurum",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GuncelleyenKisiID",
                table: "Kurum",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OlusturanKisiID",
                table: "Kurum",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellenmeTarihi",
                table: "Kisi",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GuncelleyenKisiID",
                table: "Kisi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OlusturanKisiID",
                table: "Kisi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RolID",
                table: "Kisi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "SilindiMi",
                table: "Kisi",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellenmeTarihi",
                table: "GirilenSinav",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GuncelleyenKisiID",
                table: "GirilenSinav",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OlusturanKisiID",
                table: "GirilenSinav",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellenmeTarihi",
                table: "Dersler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GuncelleyenKisiID",
                table: "Dersler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OlusturanKisiID",
                table: "Dersler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellenmeTarihi",
                table: "Bolumler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GuncelleyenKisiID",
                table: "Bolumler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OlusturanKisiID",
                table: "Bolumler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellenmeTarihi",
                table: "Abonelik",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GuncelleyenKisiID",
                table: "Abonelik",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OlusturanKisiID",
                table: "Abonelik",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Roller",
                columns: table => new
                {
                    TabloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RolAciklamasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Roller", x => x.TabloID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roller");

            migrationBuilder.DropColumn(
                name: "GuncellenmeTarihi",
                table: "Yapilacaklar");

            migrationBuilder.DropColumn(
                name: "GuncelleyenKisiID",
                table: "Yapilacaklar");

            migrationBuilder.DropColumn(
                name: "OlusturanKisiID",
                table: "Yapilacaklar");

            migrationBuilder.DropColumn(
                name: "GuncellenmeTarihi",
                table: "Sinav");

            migrationBuilder.DropColumn(
                name: "GuncelleyenKisiID",
                table: "Sinav");

            migrationBuilder.DropColumn(
                name: "OlusturanKisiID",
                table: "Sinav");

            migrationBuilder.DropColumn(
                name: "GuncellenmeTarihi",
                table: "Referanslarimiz");

            migrationBuilder.DropColumn(
                name: "GuncelleyenKisiID",
                table: "Referanslarimiz");

            migrationBuilder.DropColumn(
                name: "OlusturanKisiID",
                table: "Referanslarimiz");

            migrationBuilder.DropColumn(
                name: "GuncellenmeTarihi",
                table: "MedyaKutuphanesi");

            migrationBuilder.DropColumn(
                name: "GuncelleyenKisiID",
                table: "MedyaKutuphanesi");

            migrationBuilder.DropColumn(
                name: "OlusturanKisiID",
                table: "MedyaKutuphanesi");

            migrationBuilder.DropColumn(
                name: "GuncellenmeTarihi",
                table: "Kurum");

            migrationBuilder.DropColumn(
                name: "GuncelleyenKisiID",
                table: "Kurum");

            migrationBuilder.DropColumn(
                name: "OlusturanKisiID",
                table: "Kurum");

            migrationBuilder.DropColumn(
                name: "GuncellenmeTarihi",
                table: "Kisi");

            migrationBuilder.DropColumn(
                name: "GuncelleyenKisiID",
                table: "Kisi");

            migrationBuilder.DropColumn(
                name: "OlusturanKisiID",
                table: "Kisi");

            migrationBuilder.DropColumn(
                name: "RolID",
                table: "Kisi");

            migrationBuilder.DropColumn(
                name: "SilindiMi",
                table: "Kisi");

            migrationBuilder.DropColumn(
                name: "GuncellenmeTarihi",
                table: "GirilenSinav");

            migrationBuilder.DropColumn(
                name: "GuncelleyenKisiID",
                table: "GirilenSinav");

            migrationBuilder.DropColumn(
                name: "OlusturanKisiID",
                table: "GirilenSinav");

            migrationBuilder.DropColumn(
                name: "GuncellenmeTarihi",
                table: "Dersler");

            migrationBuilder.DropColumn(
                name: "GuncelleyenKisiID",
                table: "Dersler");

            migrationBuilder.DropColumn(
                name: "OlusturanKisiID",
                table: "Dersler");

            migrationBuilder.DropColumn(
                name: "GuncellenmeTarihi",
                table: "Bolumler");

            migrationBuilder.DropColumn(
                name: "GuncelleyenKisiID",
                table: "Bolumler");

            migrationBuilder.DropColumn(
                name: "OlusturanKisiID",
                table: "Bolumler");

            migrationBuilder.DropColumn(
                name: "GuncellenmeTarihi",
                table: "Abonelik");

            migrationBuilder.DropColumn(
                name: "GuncelleyenKisiID",
                table: "Abonelik");

            migrationBuilder.DropColumn(
                name: "OlusturanKisiID",
                table: "Abonelik");

            migrationBuilder.RenameColumn(
                name: "SilenKisiID",
                table: "Yapilacaklar",
                newName: "EkleyenKisiID");

            migrationBuilder.RenameColumn(
                name: "OlusturulmaTarihi",
                table: "Yapilacaklar",
                newName: "EklenmeTarihi");

            migrationBuilder.RenameColumn(
                name: "SilenKisiID",
                table: "Sinav",
                newName: "EkleyenKisiID");

            migrationBuilder.RenameColumn(
                name: "OlusturulmaTarihi",
                table: "Sinav",
                newName: "EklenmeTarihi");

            migrationBuilder.RenameColumn(
                name: "SilenKisiID",
                table: "Referanslarimiz",
                newName: "EkleyenKisiID");

            migrationBuilder.RenameColumn(
                name: "OlusturulmaTarihi",
                table: "Referanslarimiz",
                newName: "EklenmeTarihi");

            migrationBuilder.RenameColumn(
                name: "SilenKisiID",
                table: "MedyaKutuphanesi",
                newName: "EkleyenKisiID");

            migrationBuilder.RenameColumn(
                name: "OlusturulmaTarihi",
                table: "MedyaKutuphanesi",
                newName: "EklenmeTarihi");

            migrationBuilder.RenameColumn(
                name: "SilenKisiID",
                table: "Kurum",
                newName: "EkleyenKisiID");

            migrationBuilder.RenameColumn(
                name: "OlusturulmaTarihi",
                table: "Kurum",
                newName: "EklenmeTarihi");

            migrationBuilder.RenameColumn(
                name: "SilinmeTarihi",
                table: "Kisi",
                newName: "KisiSonGirisTarihi");

            migrationBuilder.RenameColumn(
                name: "SilenKisiID",
                table: "Kisi",
                newName: "KisiSilindiMi");

            migrationBuilder.RenameColumn(
                name: "OlusturulmaTarihi",
                table: "Kisi",
                newName: "KisiKayitTarihi");

            migrationBuilder.RenameColumn(
                name: "SilenKisiID",
                table: "GirilenSinav",
                newName: "EkleyenKisiID");

            migrationBuilder.RenameColumn(
                name: "OlusturulmaTarihi",
                table: "GirilenSinav",
                newName: "EklenmeTarihi");

            migrationBuilder.RenameColumn(
                name: "SilenKisiID",
                table: "Dersler",
                newName: "EkleyenKisiID");

            migrationBuilder.RenameColumn(
                name: "OlusturulmaTarihi",
                table: "Dersler",
                newName: "EklenmeTarihi");

            migrationBuilder.RenameColumn(
                name: "SilenKisiID",
                table: "Bolumler",
                newName: "EkleyenKisiID");

            migrationBuilder.RenameColumn(
                name: "OlusturulmaTarihi",
                table: "Bolumler",
                newName: "EklenmeTarihi");

            migrationBuilder.RenameColumn(
                name: "SilenKisiID",
                table: "Abonelik",
                newName: "EkleyenKisiID");

            migrationBuilder.RenameColumn(
                name: "OlusturulmaTarihi",
                table: "Abonelik",
                newName: "EklenmeTarihi");
        }
    }
}
