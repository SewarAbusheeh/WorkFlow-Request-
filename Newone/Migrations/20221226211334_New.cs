using Microsoft.EntityFrameworkCore.Migrations;

namespace Newone.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contatnt",
                table: "CourseLessons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "CourseLessons",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contatnt",
                table: "CourseLessons");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "CourseLessons");
        }
    }
}
