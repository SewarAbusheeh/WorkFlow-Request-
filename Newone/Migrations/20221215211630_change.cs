using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Newone.Migrations
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requesttoenrolls_AspNetUsers_UserId1",
                table: "Requesttoenrolls");

            migrationBuilder.DropIndex(
                name: "IX_Requesttoenrolls_UserId1",
                table: "Requesttoenrolls");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Requesttoenrolls");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Requesttoenrolls",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Requesttoenrolls_UserId",
                table: "Requesttoenrolls",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requesttoenrolls_AspNetUsers_UserId",
                table: "Requesttoenrolls",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requesttoenrolls_AspNetUsers_UserId",
                table: "Requesttoenrolls");

            migrationBuilder.DropIndex(
                name: "IX_Requesttoenrolls_UserId",
                table: "Requesttoenrolls");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Requesttoenrolls",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Requesttoenrolls",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requesttoenrolls_UserId1",
                table: "Requesttoenrolls",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Requesttoenrolls_AspNetUsers_UserId1",
                table: "Requesttoenrolls",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
