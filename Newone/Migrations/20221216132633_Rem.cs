using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Newone.Migrations
{
    public partial class Rem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Topic1",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Topic2",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Topic3",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TopicTime1",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TopicTime2",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "TopicTime3",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Topic1",
                table: "ComingCourses");

            migrationBuilder.DropColumn(
                name: "Topic2",
                table: "ComingCourses");

            migrationBuilder.DropColumn(
                name: "Topic3",
                table: "ComingCourses");

            migrationBuilder.DropColumn(
                name: "TopicTime1",
                table: "ComingCourses");

            migrationBuilder.DropColumn(
                name: "TopicTime2",
                table: "ComingCourses");

            migrationBuilder.DropColumn(
                name: "TopicTime3",
                table: "ComingCourses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Topic1",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Topic2",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Topic3",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TopicTime1",
                table: "Courses",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TopicTime2",
                table: "Courses",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TopicTime3",
                table: "Courses",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "Topic1",
                table: "ComingCourses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Topic2",
                table: "ComingCourses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Topic3",
                table: "ComingCourses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TopicTime1",
                table: "ComingCourses",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TopicTime2",
                table: "ComingCourses",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TopicTime3",
                table: "ComingCourses",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
