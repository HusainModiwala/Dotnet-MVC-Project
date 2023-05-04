using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCAssignment2.Migrations
{
    public partial class req : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_BookReadingEvents_EventTitle",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "EventTitle",
                table: "Comments",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_BookReadingEvents_EventTitle",
                table: "Comments",
                column: "EventTitle",
                principalTable: "BookReadingEvents",
                principalColumn: "Title",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_BookReadingEvents_EventTitle",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "EventTitle",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_BookReadingEvents_EventTitle",
                table: "Comments",
                column: "EventTitle",
                principalTable: "BookReadingEvents",
                principalColumn: "Title",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
