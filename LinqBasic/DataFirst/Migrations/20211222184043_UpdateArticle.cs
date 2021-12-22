using Microsoft.EntityFrameworkCore.Migrations;

namespace DataFirst.Migrations
{
    public partial class UpdateArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Article");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Article",
                newName: "ArticleContent");

            migrationBuilder.AddColumn<string>(
                name: "ArticleName",
                table: "Article",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArticleName",
                table: "Article");

            migrationBuilder.RenameColumn(
                name: "ArticleContent",
                table: "Article",
                newName: "Content");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Article",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
