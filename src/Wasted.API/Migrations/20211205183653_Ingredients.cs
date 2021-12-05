using Microsoft.EntityFrameworkCore.Migrations;

namespace WastedAPI.Migrations
{
    public partial class Ingredients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => new { x.DishId, x.ProductId });
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "DishId", "ProductId", "Amount" },
                values: new object[] { 1, 1, 100 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "DishId", "ProductId", "Amount" },
                values: new object[] { 1, 3, 200 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });
        }
    }
}
