using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShiffi.Migrations
{
    public partial class onlyobjectnot2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donation_Donors_DonorsId",
                table: "Donation");

            migrationBuilder.AlterColumn<string>(
                name: "DonorsId",
                table: "Donation",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Donation_Donors_DonorsId",
                table: "Donation",
                column: "DonorsId",
                principalTable: "Donors",
                principalColumn: "DonorsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donation_Donors_DonorsId",
                table: "Donation");

            migrationBuilder.AlterColumn<string>(
                name: "DonorsId",
                table: "Donation",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Donation_Donors_DonorsId",
                table: "Donation",
                column: "DonorsId",
                principalTable: "Donors",
                principalColumn: "DonorsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
