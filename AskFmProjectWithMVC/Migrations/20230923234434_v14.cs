using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AskFmProjectWithMVC.Migrations
{
    /// <inheritdoc />
    public partial class v14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questions_answers_answer_id",
                table: "questions");

            migrationBuilder.AlterColumn<int>(
                name: "answer_id",
                table: "questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_questions_answers_answer_id",
                table: "questions",
                column: "answer_id",
                principalTable: "answers",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questions_answers_answer_id",
                table: "questions");

            migrationBuilder.AlterColumn<int>(
                name: "answer_id",
                table: "questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_questions_answers_answer_id",
                table: "questions",
                column: "answer_id",
                principalTable: "answers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
