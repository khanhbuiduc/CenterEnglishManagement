using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CenterEnglishManagement.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRestrictDeleteBehaviorInStudentParent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentParents_Users_ParentId",
                table: "StudentParents");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentParents_Users_StudentId",
                table: "StudentParents");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentParents_Users_ParentId",
                table: "StudentParents",
                column: "ParentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentParents_Users_StudentId",
                table: "StudentParents",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentParents_Users_ParentId",
                table: "StudentParents");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentParents_Users_StudentId",
                table: "StudentParents");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentParents_Users_ParentId",
                table: "StudentParents",
                column: "ParentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentParents_Users_StudentId",
                table: "StudentParents",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
