using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YksProject.DataAccessLayer.Migrations
{
    public partial class kisiDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserDateTime",
                table: "AspNetUsers",
                newName: "KisiSonGirisTarihi");

            migrationBuilder.AddColumn<DateTime>(
                name: "KisiDogumTarihi",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "KisiKayitTarihi",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KisiDogumTarihi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KisiKayitTarihi",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "KisiSonGirisTarihi",
                table: "AspNetUsers",
                newName: "UserDateTime");
        }
    }
}
