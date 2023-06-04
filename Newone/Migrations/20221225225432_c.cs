using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Newone.Migrations
{
    public partial class c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseLessons",
                columns: table => new
                {
                    CourseLessonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerialNumber = table.Column<int>(type: "int", nullable: false),
                    LatestCourseId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLessons", x => x.CourseLessonId);
                    table.ForeignKey(
                        name: "FK_CourseLessons_LatestCourses_LatestCourseId",
                        column: x => x.LatestCourseId,
                        principalTable: "LatestCourses",
                        principalColumn: "LatestCourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseLessons_LatestCourseId",
                table: "CourseLessons",
                column: "LatestCourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseLessons");
        }
    }
}
