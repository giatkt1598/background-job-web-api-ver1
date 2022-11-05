using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackgroundJobsWebApi.Domain.Migrations
{
    public partial class AddColumnPriority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "AppBackgroundJobs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "AppBackgroundJobs");
        }
    }
}
