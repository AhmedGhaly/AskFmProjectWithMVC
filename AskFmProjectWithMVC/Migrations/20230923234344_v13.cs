using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AskFmProjectWithMVC.Migrations
{
    /// <inheritdoc />
    public partial class v13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "answer_id",
                table: "questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_questions_answer_id",
                table: "questions",
                column: "answer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_questions_answers_answer_id",
                table: "questions",
                column: "answer_id",
                principalTable: "answers",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questions_answers_answer_id",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "IX_questions_answer_id",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "answer_id",
                table: "questions");
        }
    }
}
