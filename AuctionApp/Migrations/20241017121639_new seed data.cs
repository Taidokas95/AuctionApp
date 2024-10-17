using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionApp.Migrations
{
    /// <inheritdoc />
    public partial class newseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDb",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Description", "EndTime", "Name", "StartingPrice", "UserId" },
                values: new object[] { "Spöke", new DateTime(2024, 10, 22, 14, 16, 37, 539, DateTimeKind.Local).AddTicks(6988), "Test: Halloween kostym", 100, "hannah.kanjah@gmail.com" });

            migrationBuilder.InsertData(
                table: "AuctionDb",
                columns: new[] { "Id", "Description", "EndTime", "Name", "StartingPrice", "UserId", "WinnerId" },
                values: new object[] { -2, "I plast", new DateTime(2024, 10, 22, 14, 16, 37, 539, DateTimeKind.Local).AddTicks(7072), "Test: Pumpa", 150, "Test2", null });

            migrationBuilder.UpdateData(
                table: "BidDb",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Amount", "Date" },
                values: new object[] { 110, new DateTime(2024, 10, 17, 14, 16, 37, 539, DateTimeKind.Local).AddTicks(7462) });

            migrationBuilder.InsertData(
                table: "BidDb",
                columns: new[] { "Id", "Amount", "AuctionId", "Date", "UserId" },
                values: new object[] { -2, 160, -2, new DateTime(2024, 10, 17, 14, 16, 37, 539, DateTimeKind.Local).AddTicks(7472), "test2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BidDb",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "AuctionDb",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.UpdateData(
                table: "AuctionDb",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Description", "EndTime", "Name", "StartingPrice", "UserId" },
                values: new object[] { "Auction Description", new DateTime(2024, 10, 22, 11, 53, 0, 837, DateTimeKind.Local).AddTicks(1780), "Auction -1", -1, "test" });

            migrationBuilder.UpdateData(
                table: "BidDb",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Amount", "Date" },
                values: new object[] { -1, new DateTime(2024, 10, 17, 11, 53, 0, 837, DateTimeKind.Local).AddTicks(2358) });
        }
    }
}
