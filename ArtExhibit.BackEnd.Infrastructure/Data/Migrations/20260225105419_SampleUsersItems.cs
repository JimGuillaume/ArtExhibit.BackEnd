using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ArtExhibit.BackEnd.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SampleUsersItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "UserEmail", "UserName", "UserPhone", "UserTypeId" },
                values: new object[,]
                {
                    { 1, "Marie", "Dubois", "marie.dubois@example.com", "marie_artist", "0612345678", 1 },
                    { 2, "Pierre", "Martin", "pierre.martin@example.com", "pierre_sculptor", "0623456789", 1 },
                    { 3, "Sophie", "Bernard", "sophie.bernard@example.com", "sophie_photo", "0634567890", 1 },
                    { 4, "Jean", "Admin", "admin@example.com", "admin_user", "0645678901", 2 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "Tags", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Beautiful oil painting capturing the golden hour over the Eiffel Tower", "Sunset Over Paris", 1250.5f, "[\"landscape\",\"paris\",\"sunset\",\"oil\"]", 1 },
                    { 2, 1, "Modern abstract painting with vibrant colors", "Abstract Dreams", 890f, "[\"abstract\",\"modern\",\"colorful\"]", 1 },
                    { 3, 2, "Life-size bronze sculpture of an ancient warrior", "Bronze Warrior", 5500f, "[\"bronze\",\"warrior\",\"ancient\",\"statue\"]", 2 },
                    { 4, 2, "Elegant marble sculpture depicting a ballet dancer", "Dancing Figure", 3200f, "[\"marble\",\"ballet\",\"dance\",\"elegant\"]", 2 },
                    { 5, 3, "Black and white photography series of Parisian streets", "Urban Streets", 450f, "[\"photography\",\"black-white\",\"urban\",\"paris\"]", 3 },
                    { 6, 3, "Stunning landscape photography collection", "Nature's Beauty", 680f, "[\"nature\",\"landscape\",\"photography\",\"color\"]", 3 },
                    { 7, 4, "Detailed charcoal drawing of a human face", "Portrait Study", 320f, "[\"portrait\",\"charcoal\",\"drawing\",\"realistic\"]", 1 },
                    { 8, 4, "Collection of detailed plant and flower sketches", "Botanical Sketches", 280f, "[\"botanical\",\"sketches\",\"nature\",\"pencil\"]", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
