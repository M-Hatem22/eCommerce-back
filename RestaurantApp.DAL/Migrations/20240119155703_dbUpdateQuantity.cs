using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class dbUpdateQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantityInInventory",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityInInventory",
                table: "Items");
        }
    }
}
