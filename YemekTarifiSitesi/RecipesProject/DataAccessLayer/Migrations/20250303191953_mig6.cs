using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Meals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_AppUserId",
                table: "Meals",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_AspNetUsers_AppUserId",
                table: "Meals",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_AspNetUsers_AppUserId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_AppUserId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Meals");
        }
    }
}
