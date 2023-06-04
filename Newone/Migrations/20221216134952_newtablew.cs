using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Newone.Migrations
{
    public partial class newtablew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LatestCourses",
                columns: table => new
                {
                    LatestCourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    blockQute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoreDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LatestCourses", x => x.LatestCourseId);
                    table.ForeignKey(
                        name: "FK_LatestCourses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LatestCourses_CategoryId",
                table: "LatestCourses",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LatestCourses");
        }
    }
}
