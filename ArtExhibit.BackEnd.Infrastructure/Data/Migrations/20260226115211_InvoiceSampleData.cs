using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtExhibit.BackEnd.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InvoiceSampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "Amount", "Date", "OrderId" },
                values: new object[,]
                {
                    { 1, 850f, new DateOnly(2024, 1, 21), 1 },
                    { 2, 3950f, new DateOnly(2024, 2, 29), 2 },
                    { 3, 450f, new DateOnly(2024, 2, 11), 3 },
                    { 4, 680f, new DateOnly(2024, 3, 21), 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
