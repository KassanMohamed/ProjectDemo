using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterviewProjectInfrastructure.Migrations
{
    public partial class Yearofpublication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlaceOfPublication",
                table: "Book",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlaceOfPublication",
                table: "Book");
        }
    }
}
