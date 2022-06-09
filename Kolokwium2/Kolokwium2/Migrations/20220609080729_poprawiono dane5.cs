using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolokwium2.Migrations
{
    public partial class poprawionodane5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Musicians",
                keyColumn: "IdMusician",
                keyValue: 4,
                column: "LastName",
                value: "Wierzbicki");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Musicians",
                keyColumn: "IdMusician",
                keyValue: 4,
                column: "LastName",
                value: "Josełka");
        }
    }
}
