using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionApp.Migrations
{
    /// <inheritdoc />
    public partial class updatedseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDb",
                keyColumn: "Id",
                keyValue: -2,
                column: "EndTime",
                value: new DateTime(2024, 10, 22, 14, 50, 34, 573, DateTimeKind.Local).AddTicks(3973));

            migrationBuilder.UpdateData(
                table: "AuctionDb",
                keyColumn: "Id",
                keyValue: -1,
                column: "EndTime",
                value: new DateTime(2024, 10, 22, 14, 50, 34, 573, DateTimeKind.Local).AddTicks(3910));

            migrationBuilder.UpdateData(
                table: "BidDb",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2024, 10, 17, 14, 50, 34, 573, DateTimeKind.Local).AddTicks(4206), "hannah.kanjah@gmail.com" });

            migrationBuilder.UpdateData(
                table: "BidDb",
                keyColumn: "Id",
                keyValue: -1,
                column: "Date",
                value: new DateTime(2024, 10, 17, 14, 50, 34, 573, DateTimeKind.Local).AddTicks(4202));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDb",
                keyColumn: "Id",
                keyValue: -2,
                column: "EndTime",
                value: new DateTime(2024, 10, 22, 14, 16, 37, 539, DateTimeKind.Local).AddTicks(7072));

            migrationBuilder.UpdateData(
                table: "AuctionDb",
                keyColumn: "Id",
                keyValue: -1,
                column: "EndTime",
                value: new DateTime(2024, 10, 22, 14, 16, 37, 539, DateTimeKind.Local).AddTicks(6988));

            migrationBuilder.UpdateData(
                table: "BidDb",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2024, 10, 17, 14, 16, 37, 539, DateTimeKind.Local).AddTicks(7472), "test2" });

            migrationBuilder.UpdateData(
                table: "BidDb",
                keyColumn: "Id",
                keyValue: -1,
                column: "Date",
                value: new DateTime(2024, 10, 17, 14, 16, 37, 539, DateTimeKind.Local).AddTicks(7462));
        }
    }
}
