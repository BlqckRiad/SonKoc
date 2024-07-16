using Microsoft.EntityFrameworkCore.Migrations;

namespace YksProject.DataAccessLayer.Migrations
{
    public partial class KisiTableOnlineRowAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "UserOnlineMi",
                table: "Kisi",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserOnlineMi",
                table: "Kisi");
        }
    }
}
