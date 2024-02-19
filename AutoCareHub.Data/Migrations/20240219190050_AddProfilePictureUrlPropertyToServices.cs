using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoCareHub.Data.Migrations
{
    public partial class AddProfilePictureUrlPropertyToServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Services");
        }
    }
}
