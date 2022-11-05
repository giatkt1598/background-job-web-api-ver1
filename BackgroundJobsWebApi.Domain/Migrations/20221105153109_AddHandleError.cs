using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackgroundJobsWebApi.Domain.Migrations
{
    public partial class AddHandleError : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Detail",
                table: "AppBackgroundJobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsFailure",
                table: "AppBackgroundJobs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detail",
                table: "AppBackgroundJobs");

            migrationBuilder.DropColumn(
                name: "IsFailure",
                table: "AppBackgroundJobs");
        }
    }
}
