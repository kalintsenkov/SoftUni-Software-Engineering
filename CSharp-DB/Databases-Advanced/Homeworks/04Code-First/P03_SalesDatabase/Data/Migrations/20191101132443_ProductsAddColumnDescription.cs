namespace P03_SalesDatabase.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ProductsAddColumnDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                maxLength: 250,
                nullable: true,
                defaultValue: "No description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");
        }
    }
}
