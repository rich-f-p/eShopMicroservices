using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderMicroservice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street1 = table.Column<string>(type: "varchar(50)", nullable: false),
                    Street2 = table.Column<string>(type: "varchar(50)", nullable: false),
                    City = table.Column<string>(type: "varchar(50)", nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(5)", nullable: false),
                    State = table.Column<string>(type: "varchar(52)", nullable: false),
                    Country = table.Column<string>(type: "varchar(56)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Gender = table.Column<string>(type: "varchar(50)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(15)", nullable: false),
                    Profile_PIC = table.Column<string>(type: "varchar(300)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "varchar(50)", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    PaymentName = table.Column<string>(type: "varchar(100)", nullable: false),
                    ShippingAddress = table.Column<string>(type: "varchar(100)", nullable: false),
                    ShippingMethod = table.Column<string>(type: "varchar(30)", nullable: false),
                    BillAmount = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Order_Status = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment_Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    Address_Id = table.Column<int>(type: "int", nullable: false),
                    IsDefaultAddress = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Addresses_Addresses_Address_Id",
                        column: x => x.Address_Id,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Addresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Order_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Id = table.Column<int>(type: "int", nullable: false),
                    Product_Id = table.Column<int>(type: "int", nullable: false),
                    Product_Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Details_Orders_Order_Id",
                        column: x => x.Order_Id,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Payment_Type_Id = table.Column<int>(type: "int", nullable: false),
                    Provider = table.Column<string>(type: "varchar(60)", nullable: false),
                    AccountNumber = table.Column<string>(type: "varchar(17)", nullable: false),
                    Expiry = table.Column<string>(type: "varchar(10)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Payment_TypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentMethods_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentMethods_Payment_Types_Payment_TypeId",
                        column: x => x.Payment_TypeId,
                        principalTable: "Payment_Types",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Shopping_Cart_Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cart_Id = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "varchar(100)", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopping_Cart_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shopping_Cart_Items_ShoppingCarts_Cart_Id",
                        column: x => x.Cart_Id,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_Details_Order_Id",
                table: "Order_Details",
                column: "Order_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_CustomerId",
                table: "PaymentMethods",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_Payment_TypeId",
                table: "PaymentMethods",
                column: "Payment_TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Shopping_Cart_Items_Cart_Id",
                table: "Shopping_Cart_Items",
                column: "Cart_Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Addresses_Address_Id",
                table: "User_Addresses",
                column: "Address_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Addresses_CustomerId",
                table: "User_Addresses",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_Details");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Shopping_Cart_Items");

            migrationBuilder.DropTable(
                name: "User_Addresses");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Payment_Types");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
