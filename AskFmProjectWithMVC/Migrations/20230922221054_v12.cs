using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AskFmProjectWithMVC.Migrations
{
    /// <inheritdoc />
    public partial class v12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questions_users_user_who_ask_id",
                table: "questions");

            migrationBuilder.AlterColumn<int>(
                name: "user_who_ask_id",
                table: "questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_questions_users_user_who_ask_id",
                table: "questions",
                column: "user_who_ask_id",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_questions_users_user_who_ask_id",
                table: "questions");

            migrationBuilder.AlterColumn<int>(
                name: "user_who_ask_id",
                table: "questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_questions_users_user_who_ask_id",
                table: "questions",
                column: "user_who_ask_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
