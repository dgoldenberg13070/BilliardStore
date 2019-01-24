using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsStore.Migrations
{
    public partial class sasdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartLine_Orders_OrderID1",
                table: "CartLine");

            migrationBuilder.DropIndex(
                name: "IX_CartLine_OrderID1",
                table: "CartLine");

            migrationBuilder.DropColumn(
                name: "OrderID1",
                table: "CartLine");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderID1",
                table: "CartLine",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartLine_OrderID1",
                table: "CartLine",
                column: "OrderID1");

            migrationBuilder.AddForeignKey(
                name: "FK_CartLine_Orders_OrderID1",
                table: "CartLine",
                column: "OrderID1",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
