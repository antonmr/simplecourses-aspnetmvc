using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCourses.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNullables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contents_CategoryItems_CategoryItemId",
                table: "Contents");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryItemId",
                table: "Contents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_CategoryItems_CategoryItemId",
                table: "Contents",
                column: "CategoryItemId",
                principalTable: "CategoryItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contents_CategoryItems_CategoryItemId",
                table: "Contents");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryItemId",
                table: "Contents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_CategoryItems_CategoryItemId",
                table: "Contents",
                column: "CategoryItemId",
                principalTable: "CategoryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
