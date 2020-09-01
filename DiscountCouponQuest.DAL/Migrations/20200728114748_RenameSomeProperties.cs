using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DiscountCouponQuest.DAL.Migrations
{
    public partial class RenameSomeProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "QuestHistories");

            migrationBuilder.DropColumn(
                name: "QuestPassing",
                table: "QuestHistories");

            migrationBuilder.AddColumn<bool>(
                name: "IsPassed",
                table: "QuestHistories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "QuestStart",
                table: "QuestHistories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPassed",
                table: "QuestHistories");

            migrationBuilder.DropColumn(
                name: "QuestStart",
                table: "QuestHistories");

            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "QuestHistories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "QuestPassing",
                table: "QuestHistories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
