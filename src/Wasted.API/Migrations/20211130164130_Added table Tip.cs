using Microsoft.EntityFrameworkCore.Migrations;

namespace WastedAPI.Migrations
{
    public partial class AddedtableTip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AdminApproved",
                table: "Tips",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Tips",
                keyColumn: "TipId",
                keyValue: 1,
                column: "AdminApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Tips",
                keyColumn: "TipId",
                keyValue: 2,
                column: "AdminApproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "Tips",
                keyColumn: "TipId",
                keyValue: 3,
                column: "AdminApproved",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminApproved",
                table: "Tips");
        }
    }
}
