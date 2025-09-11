using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCourses.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItems_Contents_MediaTypeId",
                table: "CategoryItems");

            migrationBuilder.RenameColumn(
                name: "ThumbnailImagePath",
                table: "Contents",
                newName: "VideoLink");

            migrationBuilder.AddColumn<int>(
                name: "CategoryItemId",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HTMLContent",
                table: "Contents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_CategoryItemId",
                table: "Contents",
                column: "CategoryItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_CategoryItems_CategoryItemId",
                table: "Contents",
                column: "CategoryItemId",
                principalTable: "CategoryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contents_CategoryItems_CategoryItemId",
                table: "Contents");

            migrationBuilder.DropIndex(
                name: "IX_Contents_CategoryItemId",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "CategoryItemId",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "HTMLContent",
                table: "Contents");

            migrationBuilder.RenameColumn(
                name: "VideoLink",
                table: "Contents",
                newName: "ThumbnailImagePath");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItems_Contents_MediaTypeId",
                table: "CategoryItems",
                column: "MediaTypeId",
                principalTable: "Contents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
