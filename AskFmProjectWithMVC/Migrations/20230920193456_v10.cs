using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AskFmProjectWithMVC.Migrations
{
    /// <inheritdoc />
    public partial class v10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_follows",
                table: "follows");

            migrationBuilder.DropIndex(
                name: "IX_follows_follower_user_id",
                table: "follows");

            migrationBuilder.DropColumn(
                name: "id",
                table: "follows");

            migrationBuilder.AddPrimaryKey(
                name: "PK_follows",
                table: "follows",
                columns: new[] { "follower_user_id", "following_user_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_follows",
                table: "follows");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "follows",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_follows",
                table: "follows",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_follows_follower_user_id",
                table: "follows",
                column: "follower_user_id");
        }
    }
}
