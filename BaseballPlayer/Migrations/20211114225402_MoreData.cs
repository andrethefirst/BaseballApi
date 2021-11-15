using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseballPlayer.Migrations
{
    public partial class MoreData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "JerseyNumber", "Name", "Position", "Team" },
                values: new object[] { 3, 34, "Cliff Lee", "Pitcher", "Phillies" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "JerseyNumber", "Name", "Position", "Team" },
                values: new object[] { 4, 27, "Vladimir Guerrero", "CF", "Angels" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 4);
        }
    }
}
