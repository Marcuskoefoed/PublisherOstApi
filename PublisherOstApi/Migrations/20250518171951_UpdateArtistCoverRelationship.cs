using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PublisherOstApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateArtistCoverRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ArtistCovers",
                columns: new[] { "ArtistId", "CoverId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArtistCovers",
                keyColumns: new[] { "ArtistId", "CoverId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ArtistCovers",
                keyColumns: new[] { "ArtistId", "CoverId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ArtistCovers",
                keyColumns: new[] { "ArtistId", "CoverId" },
                keyValues: new object[] { 2, 1 });
        }
    }
}
