using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcFlashCards.Migrations
{
    public partial class Tentativa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateIndex(
                name: "IX_FlashCards_UserId",
                table: "FlashCards",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlashCards_AspNetUsers_UserId",
                table: "FlashCards",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashCards_AspNetUsers_UserId",
                table: "FlashCards");

            migrationBuilder.DropIndex(
                name: "IX_FlashCards_UserId",
                table: "FlashCards");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FlashCards");
        }
    }
}
