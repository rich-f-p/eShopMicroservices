using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewsMicroservice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer_Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    Customer_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_Id = table.Column<int>(type: "int", nullable: false),
                    Order_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Product_Id = table.Column<int>(type: "int", nullable: false),
                    Product_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating_Value = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Review_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdminApproval = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "UnderReview")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Reviews", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer_Reviews");
        }
    }
}
