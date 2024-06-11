using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeApp.Migrations
{
    /// <inheritdoc />
    public partial class AddRecipeImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RecipeImage",
                table: "RecipeSet",
                type: "BLOB",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipeImage",
                table: "RecipeSet");
        }
    }
}
