using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtExhibit.BackEnd.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedBidsSampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SaleId = table.Column<int>(type: "INTEGER", nullable: false),
                    BuyerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<float>(type: "REAL", nullable: false),
                    PlacedAtUtc = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bids_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bids_Users_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Bids",
                columns: new[] { "Id", "Amount", "BuyerId", "PlacedAtUtc", "SaleId" },
                values: new object[,]
                {
                    { 1, 820f, 2, new DateTime(2024, 1, 18, 10, 30, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 850f, 4, new DateTime(2024, 1, 19, 14, 45, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 450f, 1, new DateTime(2024, 2, 8, 16, 10, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, 300f, 2, new DateTime(2026, 3, 20, 9, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 5, 3050f, 3, new DateTime(2024, 2, 26, 11, 20, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 6, 3100f, 4, new DateTime(2024, 2, 27, 17, 35, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 7, 1260f, 2, new DateTime(2026, 6, 10, 13, 15, 0, 0, DateTimeKind.Unspecified), 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bids_BuyerId",
                table: "Bids",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_SaleId",
                table: "Bids",
                column: "SaleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bids");
        }
    }
}
