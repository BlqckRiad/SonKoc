using Microsoft.EntityFrameworkCore.Migrations;

namespace YksProject.DataAccessLayer.Migrations
{
    public partial class MessageTableImageLengthChanged2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MesajText",
                table: "Message",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MesajText",
                table: "Message");
        }
    }
}
