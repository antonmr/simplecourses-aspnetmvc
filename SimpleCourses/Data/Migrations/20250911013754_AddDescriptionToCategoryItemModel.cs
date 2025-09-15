using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCourses.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionToCategoryItemModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CategoryItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CategoryItems");
        }
    }
}
