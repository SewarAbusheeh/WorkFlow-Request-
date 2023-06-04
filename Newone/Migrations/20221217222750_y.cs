using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Newone.Migrations
{
    public partial class y : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Approves",
                columns: table => new
                {
                    ApproveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LatestCourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approves", x => x.ApproveId);
                    table.ForeignKey(
                        name: "FK_Approves_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Approves_LatestCourses_LatestCourseId",
                        column: x => x.LatestCourseId,
                        principalTable: "LatestCourses",
                        principalColumn: "LatestCourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Approves_LatestCourseId",
                table: "Approves",
                column: "LatestCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Approves_UserId",
                table: "Approves",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Approves");
        }
    }
}
