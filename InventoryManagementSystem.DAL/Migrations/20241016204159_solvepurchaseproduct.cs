using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagementSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class solvepurchaseproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseProducts",
                table: "PurchaseProducts");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseProducts_PurchaseId",
                table: "PurchaseProducts");

            migrationBuilder.DropColumn(
                name: "PurchaseProductId",
                table: "PurchaseProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseProducts",
                table: "PurchaseProducts",
                columns: new[] { "PurchaseId", "ProductVariantId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseProducts",
                table: "PurchaseProducts");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseProductId",
                table: "PurchaseProducts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseProducts",
                table: "PurchaseProducts",
                column: "PurchaseProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseProducts_PurchaseId",
                table: "PurchaseProducts",
                column: "PurchaseId");
        }
    }
}
