using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShiffi.Migrations
{
    public partial class donators : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donors_Gifts_GiftId",
                table: "Donors");

            migrationBuilder.DropIndex(
                name: "IX_Donors_GiftId",
                table: "Donors");

            migrationBuilder.DropColumn(
                name: "GiftId",
                table: "Donors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GiftId",
                table: "Donors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donors_GiftId",
                table: "Donors",
                column: "GiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donors_Gifts_GiftId",
                table: "Donors",
                column: "GiftId",
                principalTable: "Gifts",
                principalColumn: "GiftId");
        }
    }
}
