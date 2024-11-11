using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductMicroservice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "product_Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Parent_Category_Id = table.Column<int>(type: "int", nullable: true),
                    Parent_CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_Categories_product_Categories_Parent_CategoryId",
                        column: x => x.Parent_CategoryId,
                        principalTable: "product_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category_Variations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_Id = table.Column<int>(type: "int", nullable: false),
                    Variation_Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Product_CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category_Variations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Variations_product_Categories_Product_CategoryId",
                        column: x => x.Product_CategoryId,
                        principalTable: "product_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(128)", nullable: false),
                    Description = table.Column<string>(type: "varchar(128)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Product_Image = table.Column<string>(type: "varchar(128)", nullable: false),
                    SKU = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_product_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "product_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Variation_Values",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Variation_Id = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "varchar(40)", nullable: false),
                    Category_VariationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variation_Values", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Variation_Values_Category_Variations_Category_VariationId",
                        column: x => x.Category_VariationId,
                        principalTable: "Category_Variations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "product_Variation_Values",
                columns: table => new
                {
                    Product_Id = table.Column<int>(type: "int", nullable: false),
                    Variation_Value_Id = table.Column<int>(type: "int", nullable: false),
                    Variation_ValueId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_Variation_Values", x => new { x.Product_Id, x.Variation_Value_Id });
                    table.ForeignKey(
                        name: "FK_product_Variation_Values_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_product_Variation_Values_Variation_Values_Variation_ValueId",
                        column: x => x.Variation_ValueId,
                        principalTable: "Variation_Values",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_Variations_Product_CategoryId",
                table: "Category_Variations",
                column: "Product_CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_product_Categories_Parent_CategoryId",
                table: "product_Categories",
                column: "Parent_CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_product_Variation_Values_ProductId",
                table: "product_Variation_Values",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_product_Variation_Values_Variation_ValueId",
                table: "product_Variation_Values",
                column: "Variation_ValueId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Variation_Values_Category_VariationId",
                table: "Variation_Values",
                column: "Category_VariationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_Variation_Values");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Variation_Values");

            migrationBuilder.DropTable(
                name: "Category_Variations");

            migrationBuilder.DropTable(
                name: "product_Categories");
        }
    }
}
