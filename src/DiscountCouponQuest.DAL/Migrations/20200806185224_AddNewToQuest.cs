using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscountCouponQuest.DAL.Migrations
{
    public partial class AddNewToQuest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Finish",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Quests");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Quests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Quests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Quests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "Quests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "Quests");

            migrationBuilder.AddColumn<string>(
                name: "Finish",
                table: "Quests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Start",
                table: "Quests",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
