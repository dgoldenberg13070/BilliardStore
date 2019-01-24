using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsStore.Migrations
{
    public partial class asdfasdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BraintreeNonce",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "DontSave1",
                table: "Orders",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DontSave2",
                table: "Orders",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DontSave3",
                table: "Orders",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DontSave1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DontSave2",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DontSave3",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "BraintreeNonce",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
