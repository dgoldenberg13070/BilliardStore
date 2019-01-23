using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsStore.Migrations
{
    public partial class adsfasdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Line2",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Zip",
                table: "Orders",
                newName: "Street2");

            migrationBuilder.RenameColumn(
                name: "Line3",
                table: "Orders",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "Line1",
                table: "Orders",
                newName: "Street1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Street2",
                table: "Orders",
                newName: "Zip");

            migrationBuilder.RenameColumn(
                name: "Street1",
                table: "Orders",
                newName: "Line1");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Orders",
                newName: "Line3");

            migrationBuilder.AddColumn<string>(
                name: "Line2",
                table: "Orders",
                nullable: true);
        }
    }
}
