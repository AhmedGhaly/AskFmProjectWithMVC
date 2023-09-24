using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AskFmProjectWithMVC.Migrations
{
    /// <inheritdoc />
    public partial class v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questions_users_user_id",
                table: "questions");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "questions",
                newName: "user_who_ask_id");

            migrationBuilder.RenameIndex(
                name: "IX_questions_user_id",
                table: "questions",
                newName: "IX_questions_user_who_ask_id");

            migrationBuilder.AddColumn<int>(
                name: "user_who_answer_id",
                table: "questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_questions_user_who_answer_id",
                table: "questions",
                column: "user_who_answer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_questions_users_user_who_answer_id",
                table: "questions",
                column: "user_who_answer_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_questions_users_user_who_ask_id",
                table: "questions",
                column: "user_who_ask_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questions_users_user_who_answer_id",
                table: "questions");

            migrationBuilder.DropForeignKey(
                name: "FK_questions_users_user_who_ask_id",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "IX_questions_user_who_answer_id",
                table: "questions");

            migrationBuilder.DropColumn(
                name: "user_who_answer_id",
                table: "questions");

            migrationBuilder.RenameColumn(
                name: "user_who_ask_id",
                table: "questions",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_questions_user_who_ask_id",
                table: "questions",
                newName: "IX_questions_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_questions_users_user_id",
                table: "questions",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
