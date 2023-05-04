using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCAssignment2.Migrations
{
    public partial class addednewfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Organizer",
                table: "BookReadingEvents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Organizer",
                table: "BookReadingEvents");
        }
    }
}
