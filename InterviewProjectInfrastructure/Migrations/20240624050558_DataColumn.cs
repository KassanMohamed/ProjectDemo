using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterviewProjectInfrastructure.Migrations
{
    public partial class DataColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Book",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Book");
        }
    }
}
