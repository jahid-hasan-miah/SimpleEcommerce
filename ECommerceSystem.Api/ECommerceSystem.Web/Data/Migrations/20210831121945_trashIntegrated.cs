using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceSystem.Web.Data.Migrations
{
    public partial class trashIntegrated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeleteFlag",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteFlag",
                table: "Products");
        }
    }
}
