using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_brand_categories_categoryId",
                table: "brand");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_brand_brandId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_brand",
                table: "brand");

            migrationBuilder.RenameTable(
                name: "brand",
                newName: "brands");

            

            migrationBuilder.AddPrimaryKey(
                name: "PK_brands",
                table: "brands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_brands_categories_categoryId",
                table: "brands",
                column: "categoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_brands_brandId",
                table: "Items",
                column: "brandId",
                principalTable: "brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_brands_categories_categoryId",
                table: "brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_brands_brandId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_brands",
                table: "brands");

            migrationBuilder.RenameTable(
                name: "brands",
                newName: "brand");

            migrationBuilder.RenameIndex(
                name: "IX_brands_categoryId",
                table: "brand",
                newName: "IX_brand_categoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_brand",
                table: "brand",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_brand_categories_categoryId",
                table: "brand",
                column: "categoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_brand_brandId",
                table: "Items",
                column: "brandId",
                principalTable: "brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
