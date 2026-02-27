using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtExhibit.BackEnd.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ShipmentData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    Carrier = table.Column<string>(type: "TEXT", nullable: false),
                    TrackingNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shipments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Shipments",
                columns: new[] { "Id", "Carrier", "OrderId", "Status", "TrackingNumber" },
                values: new object[,]
                {
                    { 1, "La Poste", 1, "Delivered", "LP1234567890FR" },
                    { 2, "Chronopost", 2, "Delivered", "CP9876543210FR" },
                    { 3, "DHL Express", 3, "In Transit", "DHL5678901234" },
                    { 4, "UPS", 5, "Delivered", "UPS3456789012" },
                    { 5, "Colissimo", 4, "Pending", "CL7890123456FR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_OrderId",
                table: "Shipments",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shipments");
        }
    }
}
