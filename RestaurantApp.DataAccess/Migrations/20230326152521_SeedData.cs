using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantApp.DataAccess.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "id", "Adress", "Description", "Name", "phoneNumber" },
                values: new object[] { 1, "456 Second St", "A classic French bistro", "French Bistro", "1234590" });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "id", "Adress", "Description", "Name", "phoneNumber" },
                values: new object[] { 2, "789 Third St", "A trendy Japanese sushi bar", "Sushi Bar", "1234566" });

            migrationBuilder.InsertData(
                table: "Cuisins",
                columns: new[] { "id", "Description", "Name", "Position", "RestaurantId" },
                values: new object[] { 1, "Traditional Moroccan dishes", "Moroccan", 1, 1 });

            migrationBuilder.InsertData(
                table: "Cuisins",
                columns: new[] { "id", "Description", "Name", "Position", "RestaurantId" },
                values: new object[] { 2, "Traditional French dishes", "French", 2, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cuisins",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cuisins",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
