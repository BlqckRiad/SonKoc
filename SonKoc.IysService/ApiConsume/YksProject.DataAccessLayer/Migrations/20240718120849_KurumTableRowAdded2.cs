using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YksProject.DataAccessLayer.Migrations
{
    public partial class KurumTableRowAdded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "KurumOnlineMi",
                table: "Kurum",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "KurumSonCikisTarihi",
                table: "Kurum",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "KurumSonGirisTarihi",
                table: "Kurum",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "KurumToplamGiris",
                table: "Kurum",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KurumOnlineMi",
                table: "Kurum");

            migrationBuilder.DropColumn(
                name: "KurumSonCikisTarihi",
                table: "Kurum");

            migrationBuilder.DropColumn(
                name: "KurumSonGirisTarihi",
                table: "Kurum");

            migrationBuilder.DropColumn(
                name: "KurumToplamGiris",
                table: "Kurum");
        }
    }
}
