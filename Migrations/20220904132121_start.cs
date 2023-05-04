using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCAssignment2.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookReadingEvents",
                columns: table => new
                {
                    Title = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    StartTime = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    Other = table.Column<string>(maxLength: 500, nullable: true),
                    InviteByMail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookReadingEvents", x => x.Title);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookReadingEvents");
        }
    }
}
