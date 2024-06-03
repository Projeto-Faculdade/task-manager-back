using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRenameTableStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_strudents_student_id",
                table: "tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_strudents",
                table: "strudents");

            migrationBuilder.RenameTable(
                name: "strudents",
                newName: "students");

            migrationBuilder.RenameIndex(
                name: "IX_strudents_name",
                table: "students",
                newName: "IX_students_name");

            migrationBuilder.RenameIndex(
                name: "IX_strudents_email",
                table: "students",
                newName: "IX_students_email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_students",
                table: "students",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_students_student_id",
                table: "tasks",
                column: "student_id",
                principalTable: "students",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_students_student_id",
                table: "tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_students",
                table: "students");

            migrationBuilder.RenameTable(
                name: "students",
                newName: "strudents");

            migrationBuilder.RenameIndex(
                name: "IX_students_name",
                table: "strudents",
                newName: "IX_strudents_name");

            migrationBuilder.RenameIndex(
                name: "IX_students_email",
                table: "strudents",
                newName: "IX_strudents_email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_strudents",
                table: "strudents",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_strudents_student_id",
                table: "tasks",
                column: "student_id",
                principalTable: "strudents",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
