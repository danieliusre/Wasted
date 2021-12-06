using Microsoft.EntityFrameworkCore.Migrations;

namespace WastedAPI.Migrations
{
    public partial class context : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                column: "numberOfIngredients",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2,
                column: "numberOfIngredients",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumns: new[] { "DishId", "ProductId" },
                keyValues: new object[] { 1, 1 },
                column: "Amount",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumns: new[] { "DishId", "ProductId" },
                keyValues: new object[] { 1, 3 },
                column: "Amount",
                value: 2);

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "DishId", "ProductId", "Amount" },
                values: new object[,]
                {
                    { 2, 4, 3 },
                    { 2, 5, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumns: new[] { "DishId", "ProductId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumns: new[] { "DishId", "ProductId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                column: "numberOfIngredients",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2,
                column: "numberOfIngredients",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumns: new[] { "DishId", "ProductId" },
                keyValues: new object[] { 1, 1 },
                column: "Amount",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumns: new[] { "DishId", "ProductId" },
                keyValues: new object[] { 1, 3 },
                column: "Amount",
                value: 200);
        }
    }
}
