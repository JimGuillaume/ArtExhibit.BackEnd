using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtExhibit.BackEnd.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ItemReviewEntityAndSampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemsReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Review = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsReviews", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ItemsReviews",
                columns: new[] { "Id", "ItemId", "Review", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Absolutely stunning artwork! The colors are vibrant and the detail is incredible.", 4 },
                    { 2, 1, "Beautiful piece. Perfect for my living room.", 2 },
                    { 3, 3, "Impressive sculpture with great attention to detail. Worth the price.", 1 },
                    { 4, 3, "The craftsmanship is exceptional. A true masterpiece!", 4 },
                    { 5, 5, "The photographs capture the essence of Paris beautifully.", 1 },
                    { 6, 6, "Nature's Beauty indeed! These photos are breathtaking.", 4 },
                    { 7, 6, "High quality prints with amazing composition.", 2 },
                    { 8, 4, "The marble work is exquisite. The dancer seems almost alive.", 3 },
                    { 9, 7, "Remarkable charcoal work. The emotion in the portrait is captivating.", 1 },
                    { 10, 8, "Lovely botanical sketches, very detailed and accurate.", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemsReviews");
        }
    }
}
