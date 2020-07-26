using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscountCouponQuest.DAL.Migrations
{
    public partial class NewItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Customers");
        }
    }
}
