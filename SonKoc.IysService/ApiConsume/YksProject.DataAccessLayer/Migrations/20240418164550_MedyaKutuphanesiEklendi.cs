using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YksProject.DataAccessLayer.Migrations
{
    public partial class MedyaKutuphanesiEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KisiID",
                table: "Yapilacaklar",
                newName: "EkleyenKisiID");

            migrationBuilder.RenameColumn(
                name: "GorevEklenmeTarihi",
                table: "Yapilacaklar",
                newName: "SilinmeTarihi");

            migrationBuilder.RenameColumn(
                name: "SinavEkleyenID",
                table: "Sinav",
                newName: "EkleyenKisiID");

            migrationBuilder.RenameColumn(
                name: "SinavEklenmeTarihi",
                table: "Sinav",
                newName: "SilinmeTarihi");

            migrationBuilder.AddColumn<DateTime>(
                name: "EklenmeTarihi",
                table: "Yapilacaklar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "SilindiMi",
                table: "Yapilacaklar",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "EklenmeTarihi",
                table: "Sinav",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "SilindiMi",
                table: "Sinav",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "EklenmeTarihi",
                table: "Referanslarimiz",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EkleyenKisiID",
                table: "Referanslarimiz",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "SilindiMi",
                table: "Referanslarimiz",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilinmeTarihi",
                table: "Referanslarimiz",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EklenmeTarihi",
                table: "Kurum",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EkleyenKisiID",
                table: "Kurum",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "SilindiMi",
                table: "Kurum",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilinmeTarihi",
                table: "Kurum",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EklenmeTarihi",
                table: "GirilenSinav",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EkleyenKisiID",
                table: "GirilenSinav",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "SilindiMi",
                table: "GirilenSinav",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilinmeTarihi",
                table: "GirilenSinav",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EklenmeTarihi",
                table: "Dersler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EkleyenKisiID",
                table: "Dersler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "SilindiMi",
                table: "Dersler",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilinmeTarihi",
                table: "Dersler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EklenmeTarihi",
                table: "Bolumler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EkleyenKisiID",
                table: "Bolumler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "SilindiMi",
                table: "Bolumler",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilinmeTarihi",
                table: "Bolumler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EklenmeTarihi",
                table: "Abonelik",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EkleyenKisiID",
                table: "Abonelik",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "SilindiMi",
                table: "Abonelik",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilinmeTarihi",
                table: "Abonelik",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "MedyaKutuphanesi",
                columns: table => new
                {
                    TabloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedyaAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedyaUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EkleyenKisiID = table.Column<int>(type: "int", nullable: false),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SilinmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedyaKutuphanesi", x => x.TabloID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedyaKutuphanesi");

            migrationBuilder.DropColumn(
                name: "EklenmeTarihi",
                table: "Yapilacaklar");

            migrationBuilder.DropColumn(
                name: "SilindiMi",
                table: "Yapilacaklar");

            migrationBuilder.DropColumn(
                name: "EklenmeTarihi",
                table: "Sinav");

            migrationBuilder.DropColumn(
                name: "SilindiMi",
                table: "Sinav");

            migrationBuilder.DropColumn(
                name: "EklenmeTarihi",
                table: "Referanslarimiz");

            migrationBuilder.DropColumn(
                name: "EkleyenKisiID",
                table: "Referanslarimiz");

            migrationBuilder.DropColumn(
                name: "SilindiMi",
                table: "Referanslarimiz");

            migrationBuilder.DropColumn(
                name: "SilinmeTarihi",
                table: "Referanslarimiz");

            migrationBuilder.DropColumn(
                name: "EklenmeTarihi",
                table: "Kurum");

            migrationBuilder.DropColumn(
                name: "EkleyenKisiID",
                table: "Kurum");

            migrationBuilder.DropColumn(
                name: "SilindiMi",
                table: "Kurum");

            migrationBuilder.DropColumn(
                name: "SilinmeTarihi",
                table: "Kurum");

            migrationBuilder.DropColumn(
                name: "EklenmeTarihi",
                table: "GirilenSinav");

            migrationBuilder.DropColumn(
                name: "EkleyenKisiID",
                table: "GirilenSinav");

            migrationBuilder.DropColumn(
                name: "SilindiMi",
                table: "GirilenSinav");

            migrationBuilder.DropColumn(
                name: "SilinmeTarihi",
                table: "GirilenSinav");

            migrationBuilder.DropColumn(
                name: "EklenmeTarihi",
                table: "Dersler");

            migrationBuilder.DropColumn(
                name: "EkleyenKisiID",
                table: "Dersler");

            migrationBuilder.DropColumn(
                name: "SilindiMi",
                table: "Dersler");

            migrationBuilder.DropColumn(
                name: "SilinmeTarihi",
                table: "Dersler");

            migrationBuilder.DropColumn(
                name: "EklenmeTarihi",
                table: "Bolumler");

            migrationBuilder.DropColumn(
                name: "EkleyenKisiID",
                table: "Bolumler");

            migrationBuilder.DropColumn(
                name: "SilindiMi",
                table: "Bolumler");

            migrationBuilder.DropColumn(
                name: "SilinmeTarihi",
                table: "Bolumler");

            migrationBuilder.DropColumn(
                name: "EklenmeTarihi",
                table: "Abonelik");

            migrationBuilder.DropColumn(
                name: "EkleyenKisiID",
                table: "Abonelik");

            migrationBuilder.DropColumn(
                name: "SilindiMi",
                table: "Abonelik");

            migrationBuilder.DropColumn(
                name: "SilinmeTarihi",
                table: "Abonelik");

            migrationBuilder.RenameColumn(
                name: "SilinmeTarihi",
                table: "Yapilacaklar",
                newName: "GorevEklenmeTarihi");

            migrationBuilder.RenameColumn(
                name: "EkleyenKisiID",
                table: "Yapilacaklar",
                newName: "KisiID");

            migrationBuilder.RenameColumn(
                name: "SilinmeTarihi",
                table: "Sinav",
                newName: "SinavEklenmeTarihi");

            migrationBuilder.RenameColumn(
                name: "EkleyenKisiID",
                table: "Sinav",
                newName: "SinavEkleyenID");
        }
    }
}
