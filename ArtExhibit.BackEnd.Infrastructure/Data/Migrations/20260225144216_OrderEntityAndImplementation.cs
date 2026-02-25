using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtExhibit.BackEnd.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class OrderEntityAndImplementation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalPrice = table.Column<float>(type: "REAL", nullable: false),
                    Commission = table.Column<float>(type: "REAL", nullable: false),
                    OrderStatus = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Commission", "OrderStatus", "TotalPrice", "UserId" },
                values: new object[,]
                {
                    { 1, 85f, "Completed", 850f, 1 },
                    { 2, 395f, "Completed", 3950f, 4 },
                    { 3, 45f, "Processing", 450f, 2 },
                    { 4, 125.05f, "Pending", 1250.5f, 3 },
                    { 5, 68f, "Completed", 680f, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
