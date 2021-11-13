using Microsoft.EntityFrameworkCore.Migrations;

namespace WastedAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "EnergyValue", "MeasurementUnits", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 158.48699999999999, "kg", "Apple", "Fruit" },
                    { 2, 284.54599999999999, "kg", "Troat", "Fish" },
                    { 3, 120.69199999999999, "g", "Orange", "Fruit" },
                    { 4, 262.178, "kg", "Blackberry", "Berry" },
                    { 5, 352.69799999999998, "kg", "Cheese", "Dairy" },
                    { 6, 271.745, "kg", "Bass", "Fish" },
                    { 7, 175.12450000000001, "l", "Buttermilk", "Dairy" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
