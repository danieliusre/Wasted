using Microsoft.EntityFrameworkCore.Migrations;

namespace WastedAPI.Migrations
{
    public partial class AddedtableTip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Tips",
                columns: new[] { "TipId", "Link", "Name", "TipDislikes", "TipLikes", "TipName" },
                values: new object[] { 1, "https://en.wikipedia.org/wiki/Smart_shop", "To avoid buying more food than you need, make frequent trips to the grocery store every few days rather than doing a bulk shopping trip once a week.", 0, 4, "Shop Smart" });

            migrationBuilder.InsertData(
                table: "Tips",
                columns: new[] { "TipId", "Link", "Name", "TipDislikes", "TipLikes", "TipName" },
                values: new object[] { 2, "https://www.betterhealth.vic.gov.au/health/healthyliving/food-safety-and-storage", "Separating foods that produce more ethylene gas from those that don’t is another great way to reduce food spoilage. Ethylene promotes ripening in foods and could lead to spoilage.", 0, 4, "Store Food Correctly" });

            migrationBuilder.InsertData(
                table: "Tips",
                columns: new[] { "TipId", "Link", "Name", "TipDislikes", "TipLikes", "TipName" },
                values: new object[] { 3, "https://www.masterclass.com/articles/a-guide-to-home-food-preservation-how-to-pickle-can-ferment-dry-and-preserve-at-home", "Pickling, drying, canning, fermenting, freezing and curing are all methods you can use to make food last longer, thus reducing waste.", 0, 1, "Learn to Preserve" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tips");
        }
    }
}
