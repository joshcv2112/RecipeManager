using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeApi.Migrations
{
    public partial class cookbook_table_new_cols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "IsActive",
                table: "cookbooks",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "cookbooks",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_cookbooks_CookbookId",
                table: "cookbooks",
                column: "CookbookId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_cookbooks_CookbookId",
                table: "cookbooks");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "cookbooks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "cookbooks");
        }
    }
}
