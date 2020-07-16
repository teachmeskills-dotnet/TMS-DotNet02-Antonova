using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscountCouponQuest.DAL.Migrations
{
    public partial class AddNewItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestHistories_Quests_CouponId",
                table: "QuestHistories");

            migrationBuilder.DropIndex(
                name: "IX_QuestHistories_CouponId",
                table: "QuestHistories");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "CouponId",
                table: "QuestHistories");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "QuestHistories");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Providers");

            migrationBuilder.AddColumn<int>(
                name: "Bonus",
                table: "Quests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Distance",
                table: "Quests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Finish",
                table: "Quests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Quests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Start",
                table: "Quests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "Quests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestId",
                table: "QuestHistories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "QuestPassing",
                table: "QuestHistories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_QuestHistories_QuestId",
                table: "QuestHistories",
                column: "QuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestHistories_Quests_QuestId",
                table: "QuestHistories",
                column: "QuestId",
                principalTable: "Quests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestHistories_Quests_QuestId",
                table: "QuestHistories");

            migrationBuilder.DropIndex(
                name: "IX_QuestHistories_QuestId",
                table: "QuestHistories");

            migrationBuilder.DropColumn(
                name: "Bonus",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "Distance",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "Finish",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "QuestId",
                table: "QuestHistories");

            migrationBuilder.DropColumn(
                name: "QuestPassing",
                table: "QuestHistories");

            migrationBuilder.AddColumn<int>(
                name: "Discount",
                table: "Quests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CouponId",
                table: "QuestHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "QuestHistories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestHistories_CouponId",
                table: "QuestHistories",
                column: "CouponId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestHistories_Quests_CouponId",
                table: "QuestHistories",
                column: "CouponId",
                principalTable: "Quests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
