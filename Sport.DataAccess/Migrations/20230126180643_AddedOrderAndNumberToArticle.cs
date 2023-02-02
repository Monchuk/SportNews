using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sport.API.Migrations
{
    public partial class AddedOrderAndNumberToArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Articles");
        }
    }
}
