using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Adding_Soft_Delete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "ShoppingCarts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Purchases",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "PurchaseProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "productVariants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Payments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "orderProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "cartProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "PurchaseProducts");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "productVariants");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "orderProducts");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "cartProducts");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "AspNetUsers");
        }
    }
}
