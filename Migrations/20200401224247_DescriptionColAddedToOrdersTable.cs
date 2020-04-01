using Microsoft.EntityFrameworkCore.Migrations;

namespace Customer_Orders.Migrations
{
    public partial class DescriptionColAddedToOrdersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Orders");
        }
    }
}
