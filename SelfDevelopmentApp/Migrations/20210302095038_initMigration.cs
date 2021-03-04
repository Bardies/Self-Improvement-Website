using Microsoft.EntityFrameworkCore.Migrations;

namespace SelfDevelopmentApp.Migrations
{
    public partial class initMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Current_Streak",
                table: "Habits");

            migrationBuilder.DropColumn(
                name: "Longest_Streak",
                table: "Habits");

            migrationBuilder.DropColumn(
                name: "Total_Count",
                table: "Habits");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Habits",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Habits");

            migrationBuilder.AddColumn<int>(
                name: "Current_Streak",
                table: "Habits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Longest_Streak",
                table: "Habits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Total_Count",
                table: "Habits",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
