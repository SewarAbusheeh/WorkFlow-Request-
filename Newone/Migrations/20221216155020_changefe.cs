using Microsoft.EntityFrameworkCore.Migrations;

namespace Newone.Migrations
{
    public partial class changefe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requesttoenrolls_Courses_CourseId",
                table: "Requesttoenrolls");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Requesttoenrolls",
                newName: "LatestCourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Requesttoenrolls_CourseId",
                table: "Requesttoenrolls",
                newName: "IX_Requesttoenrolls_LatestCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requesttoenrolls_LatestCourses_LatestCourseId",
                table: "Requesttoenrolls",
                column: "LatestCourseId",
                principalTable: "LatestCourses",
                principalColumn: "LatestCourseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requesttoenrolls_LatestCourses_LatestCourseId",
                table: "Requesttoenrolls");

            migrationBuilder.RenameColumn(
                name: "LatestCourseId",
                table: "Requesttoenrolls",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Requesttoenrolls_LatestCourseId",
                table: "Requesttoenrolls",
                newName: "IX_Requesttoenrolls_CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requesttoenrolls_Courses_CourseId",
                table: "Requesttoenrolls",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
