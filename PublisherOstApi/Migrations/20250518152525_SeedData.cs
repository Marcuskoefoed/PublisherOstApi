using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PublisherOstApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "Name" },
                values: new object[,]
                {
                    { 1, "Artist One" },
                    { 2, "Artist Two" },
                    { 3, "Artist Three" }
                });

            migrationBuilder.InsertData(
                table: "Covers",
                columns: new[] { "CoverId", "Title" },
                values: new object[,]
                {
                    { 1, "Cover One" },
                    { 2, "Cover Two" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Covers",
                keyColumn: "CoverId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Covers",
                keyColumn: "CoverId",
                keyValue: 2);
        }
    }
}
