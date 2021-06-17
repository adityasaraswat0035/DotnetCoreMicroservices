using Microsoft.EntityFrameworkCore.Migrations;

namespace mango.product.api.db.Migrations
{
    public partial class CategoryIdRemovedFromProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCategory_CategoryId",
                schema: "dbo",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryId",
                schema: "dbo",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "dbo",
                table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                schema: "dbo",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                schema: "dbo",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategory_CategoryId",
                schema: "dbo",
                table: "Product",
                column: "CategoryId",
                principalSchema: "dbo",
                principalTable: "ProductCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
