using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PepperShop.Migrations
{
    /// <inheritdoc />
    public partial class AddLinkTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategorieProducts",
                columns: table => new
                {
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategorieProducts", x => new { x.ProductCategoryId, x.ProductId });
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategorieProducts");
        }
    }
}
