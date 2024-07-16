using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YksProject.DataAccessLayer.Migrations
{
    public partial class sinavtablechanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SinavBaslangicTarihi",
                table: "Sinav");

            migrationBuilder.DropColumn(
                name: "SinavBitisTarihi",
                table: "Sinav");

            migrationBuilder.DropColumn(
                name: "SinavBittiMi",
                table: "Sinav");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SinavBaslangicTarihi",
                table: "Sinav",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SinavBitisTarihi",
                table: "Sinav",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "SinavBittiMi",
                table: "Sinav",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
