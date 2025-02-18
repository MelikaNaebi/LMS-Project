using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Students_StudentId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_StudentId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Assignments");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Submissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_StudentId",
                table: "Submissions",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Students_StudentId",
                table: "Submissions",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Students_StudentId",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_Submissions_StudentId",
                table: "Submissions");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Submissions");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Assignments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_StudentId",
                table: "Assignments",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Students_StudentId",
                table: "Assignments",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
