using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtExhibit.BackEnd.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SubmissionData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Submissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    RejectionReason = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Submissions_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Submissions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Submissions",
                columns: new[] { "Id", "Date", "ItemId", "RejectionReason", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 1, 5), 1, "", "Approved", 1 },
                    { 2, new DateOnly(2024, 1, 8), 2, "", "Approved", 1 },
                    { 3, new DateOnly(2024, 1, 12), 3, "", "Approved", 2 },
                    { 4, new DateOnly(2024, 2, 15), 4, "", "Approved", 2 },
                    { 5, new DateOnly(2024, 1, 28), 5, "", "Approved", 3 },
                    { 6, new DateOnly(2024, 2, 20), 6, "", "Approved", 3 },
                    { 7, new DateOnly(2024, 3, 1), 7, "", "Pending", 1 },
                    { 8, new DateOnly(2024, 3, 3), 8, "Image quality does not meet minimum requirements for exhibition", "Rejected", 3 },
                    { 9, new DateOnly(2024, 3, 12), 3, "", "Pending", 2 },
                    { 10, new DateOnly(2024, 3, 18), 1, "", "Under Review", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_ItemId",
                table: "Submissions",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Submissions_UserId",
                table: "Submissions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Submissions");
        }
    }
}
