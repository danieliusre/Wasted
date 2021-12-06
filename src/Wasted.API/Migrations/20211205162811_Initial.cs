using Microsoft.EntityFrameworkCore.Migrations;

namespace WastedAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    numberOfIngredients = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MeasurementUnits = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EnergyValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tips",
                columns: table => new
                {
                    TipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TipLikes = table.Column<int>(type: "int", nullable: false),
                    TipDislikes = table.Column<int>(type: "int", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tips", x => x.TipId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Ingredients", "Name", "Type", "numberOfIngredients" },
                values: new object[,]
                {
                    { 1, "unknown", "Chocolate Cake", "Baked", 4 },
                    { 2, "unknown", "Brownies", "Baked", 5 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EnergyValue", "MeasurementUnits", "Name", "Type" },
                values: new object[,]
                {
                    { 6, 271.745, "kg", "Bass", "Fish" },
                    { 5, 352.69799999999998, "kg", "Cheese", "Dairy" },
                    { 4, 262.178, "kg", "Blackberry", "Berry" },
                    { 7, 175.12450000000001, "l", "Buttermilk", "Dairy" },
                    { 2, 284.54599999999999, "kg", "Troat", "Fish" },
                    { 1, 158.48699999999999, "kg", "Apple", "Fruit" },
                    { 3, 120.69199999999999, "g", "Orange", "Fruit" }
                });

            migrationBuilder.InsertData(
                table: "Tips",
                columns: new[] { "TipId", "Link", "Name", "TipDislikes", "TipLikes", "TipName" },
                values: new object[,]
                {
                    { 1, "https://en.wikipedia.org/wiki/Smart_shop", "To avoid buying more food than you need, make frequent trips to the grocery store every few days rather than doing a bulk shopping trip once a week.", 0, 4, "Shop Smart" },
                    { 2, "https://www.betterhealth.vic.gov.au/health/healthyliving/food-safety-and-storage", "Separating foods that produce more ethylene gas from those that don’t is another great way to reduce food spoilage. Ethylene promotes ripening in foods and could lead to spoilage.", 0, 4, "Store Food Correctly" },
                    { 3, "https://www.masterclass.com/articles/a-guide-to-home-food-preservation-how-to-pickle-can-ferment-dry-and-preserve-at-home", "Pickling, drying, canning, fermenting, freezing and curing are all methods you can use to make food last longer, thus reducing waste.", 0, 1, "Learn to Preserve" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Role" },
                values: new object[,]
                {
                    { 4, "karolis@gmail.com", "Karolis", "Valkauskas", "Karolis123", "admin" },
                    { 1, "julius.nar@gmail.com", "Julius", "Narkunas", "JuliusNer1", "user" },
                    { 2, "danielius.rekus@gmail.com", "Danielius", "Rekus", "Danius123", "admin" },
                    { 3, "mariuks@gmail.com", "Marius", "Ivanausas", "Jhbj433h", "user" },
                    { 5, "kajus@outlook.com", "Kajus", "Orsauskas", "Kaj47474p", "user" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Tips");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
