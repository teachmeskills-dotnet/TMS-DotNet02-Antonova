using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscountCouponQuest.DAL.Migrations
{
    public partial class ChangedTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CouponHistories_Coupons_CouponId",
                table: "CouponHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_CouponHistories_Customers_CustomerId",
                table: "CouponHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Coupons_Providers_ProviderId",
                table: "Coupons");

            migrationBuilder.DropIndex(
                name: "IX_Coupons_ProviderId",
                table: "Coupons");

            migrationBuilder.DropIndex(
                name: "IX_CouponHistories_CouponId",
                table: "CouponHistories");

            migrationBuilder.DropIndex(
                name: "IX_CouponHistories_CustomerId",
                table: "CouponHistories");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Providers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderId",
                table: "Coupons",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProviderId1",
                table: "Coupons",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "CouponHistories",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CouponId",
                table: "CouponHistories",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CouponId1",
                table: "CouponHistories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "CouponHistories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_ProviderId1",
                table: "Coupons",
                column: "ProviderId1");

            migrationBuilder.CreateIndex(
                name: "IX_CouponHistories_CouponId1",
                table: "CouponHistories",
                column: "CouponId1");

            migrationBuilder.CreateIndex(
                name: "IX_CouponHistories_CustomerId1",
                table: "CouponHistories",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CouponHistories_Coupons_CouponId1",
                table: "CouponHistories",
                column: "CouponId1",
                principalTable: "Coupons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CouponHistories_Customers_CustomerId1",
                table: "CouponHistories",
                column: "CustomerId1",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Coupons_Providers_ProviderId1",
                table: "Coupons",
                column: "ProviderId1",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CouponHistories_Coupons_CouponId1",
                table: "CouponHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_CouponHistories_Customers_CustomerId1",
                table: "CouponHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Coupons_Providers_ProviderId1",
                table: "Coupons");

            migrationBuilder.DropIndex(
                name: "IX_Coupons_ProviderId1",
                table: "Coupons");

            migrationBuilder.DropIndex(
                name: "IX_CouponHistories_CouponId1",
                table: "CouponHistories");

            migrationBuilder.DropIndex(
                name: "IX_CouponHistories_CustomerId1",
                table: "CouponHistories");

            migrationBuilder.DropColumn(
                name: "ProviderId1",
                table: "Coupons");

            migrationBuilder.DropColumn(
                name: "CouponId1",
                table: "CouponHistories");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "CouponHistories");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Providers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProviderId",
                table: "Coupons",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "CouponHistories",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CouponId",
                table: "CouponHistories",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_ProviderId",
                table: "Coupons",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponHistories_CouponId",
                table: "CouponHistories",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponHistories_CustomerId",
                table: "CouponHistories",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CouponHistories_Coupons_CouponId",
                table: "CouponHistories",
                column: "CouponId",
                principalTable: "Coupons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CouponHistories_Customers_CustomerId",
                table: "CouponHistories",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Coupons_Providers_ProviderId",
                table: "Coupons",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
