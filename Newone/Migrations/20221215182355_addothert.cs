using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Newone.Migrations
{
    public partial class addothert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Requesttoenrolls",
                columns: table => new
                {
                    RequesttoenrollId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mesage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requesttoenrolls", x => x.RequesttoenrollId);
                    table.ForeignKey(
                        name: "FK_Requesttoenrolls_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requesttoenrolls_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requesttoenrolls_CourseId",
                table: "Requesttoenrolls",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Requesttoenrolls_UserId1",
                table: "Requesttoenrolls",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requesttoenrolls");
        }
    }
}
