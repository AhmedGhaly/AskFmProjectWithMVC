using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AskFmProjectWithMVC.Migrations
{
    /// <inheritdoc />
    public partial class v16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questions_answers_answer_id",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "IX_questions_answer_id",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "IX_answers_question_id",
                table: "answers");

            migrationBuilder.DropColumn(
                name: "answer_id",
                table: "questions");

            migrationBuilder.CreateIndex(
                name: "IX_answers_question_id",
                table: "answers",
                column: "question_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_answers_question_id",
                table: "answers");

            migrationBuilder.AddColumn<int>(
                name: "answer_id",
                table: "questions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_questions_answer_id",
                table: "questions",
                column: "answer_id");

            migrationBuilder.CreateIndex(
                name: "IX_answers_question_id",
                table: "answers",
                column: "question_id");

            migrationBuilder.AddForeignKey(
                name: "FK_questions_answers_answer_id",
                table: "questions",
                column: "answer_id",
                principalTable: "answers",
                principalColumn: "id");
        }
    }
}
