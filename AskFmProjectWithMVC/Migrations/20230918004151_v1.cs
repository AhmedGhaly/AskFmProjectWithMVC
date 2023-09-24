using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AskFmProjectWithMVC.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_follows_users_follower_user_id",
                table: "follows");

            migrationBuilder.AddColumn<int>(
                name: "following_user_id",
                table: "follows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_follows_following_user_id",
                table: "follows",
                column: "following_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_follows_users_follower_user_id",
                table: "follows",
                column: "follower_user_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_follows_users_following_user_id",
                table: "follows",
                column: "following_user_id",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_follows_users_follower_user_id",
                table: "follows");

            migrationBuilder.DropForeignKey(
                name: "FK_follows_users_following_user_id",
                table: "follows");

            migrationBuilder.DropIndex(
                name: "IX_follows_following_user_id",
                table: "follows");

            migrationBuilder.DropColumn(
                name: "following_user_id",
                table: "follows");

            migrationBuilder.AddForeignKey(
                name: "FK_follows_users_follower_user_id",
                table: "follows",
                column: "follower_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
