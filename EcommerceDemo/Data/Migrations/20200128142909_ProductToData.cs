using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceDemo.Data.Migrations
{
    public partial class ProductToData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductItems",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsInStock", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Windows and Linux", "\\Images\\Computer1.jpg", true, "Computer", 1000m },
                    { 2, 4, "Windows and Linux", "\\Images\\Computer2.jpg", true, "NoteBook", 900m },
                    { 3, 3, "Windows and Linux", "\\Images\\Computer3.jpg", true, "Labtop-Assus", 1500m },
                    { 4, 2, "Android and Apple", "\\Images\\Computer4.jpg", true, "Mobile-samsune 10s", 900m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
