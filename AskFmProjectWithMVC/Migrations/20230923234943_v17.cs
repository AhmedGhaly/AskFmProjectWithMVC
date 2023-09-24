using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AskFmProjectWithMVC.Migrations
{
    /// <inheritdoc />
    public partial class v17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "unkown",
                table: "questions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "unkown",
                table: "questions",
                type: "bit",
                nullable: true);
        }
    }
}
