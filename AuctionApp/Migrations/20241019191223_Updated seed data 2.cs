using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionApp.Migrations
{
    /// <inheritdoc />
    public partial class Updatedseeddata2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDb",
                keyColumn: "Id",
                keyValue: -2,
                column: "EndTime",
                value: new DateTime(2024, 10, 24, 21, 12, 23, 137, DateTimeKind.Local).AddTicks(8715));

            migrationBuilder.UpdateData(
                table: "AuctionDb",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "EndTime", "UserId" },
                values: new object[] { new DateTime(2024, 10, 24, 21, 12, 23, 137, DateTimeKind.Local).AddTicks(8667), "celagervall@gmail.com" });

            migrationBuilder.InsertData(
                table: "AuctionDb",
                columns: new[] { "Id", "Description", "EndTime", "Name", "StartingPrice", "UserId", "WinnerId" },
                values: new object[] { -3, "I Kristall", new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test: Taklampa", 5000, "Test2", "celagervall@gmail.com" });

            migrationBuilder.UpdateData(
                table: "BidDb",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2024, 10, 19, 21, 12, 23, 137, DateTimeKind.Local).AddTicks(8871), "celagervall@gmail.com" });

            migrationBuilder.UpdateData(
                table: "BidDb",
                keyColumn: "Id",
                keyValue: -1,
                column: "Date",
                value: new DateTime(2024, 10, 19, 21, 12, 23, 137, DateTimeKind.Local).AddTicks(8867));

            migrationBuilder.InsertData(
                table: "BidDb",
                columns: new[] { "Id", "Amount", "AuctionId", "Date", "UserId" },
                values: new object[] { -3, 5500, -3, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "celagervall@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BidDb",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "AuctionDb",
                keyColumn: "Id",
                keyValue: -3);

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
                columns: new[] { "EndTime", "UserId" },
                values: new object[] { new DateTime(2024, 10, 22, 14, 50, 34, 573, DateTimeKind.Local).AddTicks(3910), "hannah.kanjah@gmail.com" });

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
    }
}
