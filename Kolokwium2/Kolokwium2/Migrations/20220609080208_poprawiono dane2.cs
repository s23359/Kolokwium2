using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolokwium2.Migrations
{
    public partial class poprawionodane2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "IdTrack",
                keyValue: 1,
                column: "Duration",
                value: 330f);

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "IdTrack",
                keyValue: 2,
                column: "Duration",
                value: 425f);

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "IdTrack",
                keyValue: 3,
                column: "Duration",
                value: 255f);

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "IdTrack",
                keyValue: 4,
                column: "Duration",
                value: 115f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "IdTrack",
                keyValue: 1,
                column: "Duration",
                value: -27f);

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "IdTrack",
                keyValue: 2,
                column: "Duration",
                value: -21f);

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "IdTrack",
                keyValue: 3,
                column: "Duration",
                value: -53f);

            migrationBuilder.UpdateData(
                table: "Tracks",
                keyColumn: "IdTrack",
                keyValue: 4,
                column: "Duration",
                value: -14f);
        }
    }
}
