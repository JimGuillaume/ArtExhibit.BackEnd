using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtExhibit.BackEnd.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedJwt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiresAtUtc",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefreshTokenHash",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenRevokedAtUtc",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "RefreshTokenExpiresAtUtc", "RefreshTokenHash", "RefreshTokenRevokedAtUtc" },
                values: new object[] { "oQnjaUetVt4dyhzEnw74rJrZp7GqDfQfs8TLc8H/Aeo=", null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "RefreshTokenExpiresAtUtc", "RefreshTokenHash", "RefreshTokenRevokedAtUtc" },
                values: new object[] { "oQnjaUetVt4dyhzEnw74rJrZp7GqDfQfs8TLc8H/Aeo=", null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "RefreshTokenExpiresAtUtc", "RefreshTokenHash", "RefreshTokenRevokedAtUtc" },
                values: new object[] { "oQnjaUetVt4dyhzEnw74rJrZp7GqDfQfs8TLc8H/Aeo=", null, null, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "RefreshTokenExpiresAtUtc", "RefreshTokenHash", "RefreshTokenRevokedAtUtc" },
                values: new object[] { "oQnjaUetVt4dyhzEnw74rJrZp7GqDfQfs8TLc8H/Aeo=", null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiresAtUtc",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenRevokedAtUtc",
                table: "Users");
        }
    }
}
