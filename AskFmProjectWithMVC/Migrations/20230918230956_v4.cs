using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AskFmProjectWithMVC.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_answers_questions_questionid",
                table: "answers");

            migrationBuilder.DropIndex(
                name: "IX_answers_questionid",
                table: "answers");

            migrationBuilder.DropColumn(
                name: "questionid",
                table: "answers");

            migrationBuilder.CreateIndex(
                name: "IX_answers_question_id",
                table: "answers",
                column: "question_id");

            migrationBuilder.AddForeignKey(
                name: "FK_answers_questions_question_id",
                table: "answers",
                column: "question_id",
                principalTable: "questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_answers_questions_question_id",
                table: "answers");

            migrationBuilder.DropIndex(
                name: "IX_answers_question_id",
                table: "answers");

            migrationBuilder.AddColumn<int>(
                name: "questionid",
                table: "answers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_answers_questionid",
                table: "answers",
                column: "questionid");

            migrationBuilder.AddForeignKey(
                name: "FK_answers_questions_questionid",
                table: "answers",
                column: "questionid",
                principalTable: "questions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
