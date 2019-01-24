using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsStore.Migrations
{
    public partial class sdfasfdas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Shipped = table.Column<bool>(nullable: false),
                    TrackingNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    PlacementDate = table.Column<DateTime>(nullable: false),
                    ShipDate = table.Column<DateTime>(nullable: true),
                    DeliveryDate = table.Column<DateTime>(nullable: true),
                    SubTotal = table.Column<decimal>(type: "Money", nullable: false),
                    Tax = table.Column<decimal>(type: "Money", nullable: false),
                    Shipping = table.Column<decimal>(type: "Money", nullable: false),
                    Total = table.Column<decimal>(type: "Money", nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Street1 = table.Column<string>(nullable: false),
                    Street2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    PostalCode = table.Column<string>(nullable: false),
                    BraintreeNonce = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    Category = table.Column<string>(nullable: false),
                    ImageUrlMain = table.Column<string>(nullable: true),
                    ImageUrlSecondary = table.Column<string>(nullable: true),
                    ImageUrlOptional = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "CartLine",
                columns: table => new
                {
                    CartLineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(nullable: true),
                    ProductDescription = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(type: "Money", nullable: false),
                    LineTotal = table.Column<decimal>(type: "Money", nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    OrderID = table.Column<int>(nullable: true),
                    OrderID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartLine", x => x.CartLineID);
                    table.ForeignKey(
                        name: "FK_CartLine_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartLine_Orders_OrderID1",
                        column: x => x.OrderID1,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartLine_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartLine_OrderID",
                table: "CartLine",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_CartLine_OrderID1",
                table: "CartLine",
                column: "OrderID1");

            migrationBuilder.CreateIndex(
                name: "IX_CartLine_ProductID",
                table: "CartLine",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartLine");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
