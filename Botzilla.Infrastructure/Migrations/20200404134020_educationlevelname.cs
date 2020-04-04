using Microsoft.EntityFrameworkCore.Migrations;

namespace Botzilla.Infrastructure.Migrations
{
    public partial class educationlevelname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "EducationLevels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "EducationLevels");
        }
    }
}
