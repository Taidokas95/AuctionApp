using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionApp.Migrations
{
    /// <inheritdoc />
    public partial class _2Datatypchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WinnerId",
                table: "AuctionDb",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AuctionDb",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "EndTime", "WinnerId" },
                values: new object[] { new DateTime(2024, 10, 22, 11, 53, 0, 837, DateTimeKind.Local).AddTicks(1780), null });

            migrationBuilder.UpdateData(
                table: "BidDb",
                keyColumn: "Id",
                keyValue: -1,
                column: "Date",
                value: new DateTime(2024, 10, 17, 11, 53, 0, 837, DateTimeKind.Local).AddTicks(2358));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "WinnerId",
                table: "AuctionDb",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AuctionDb",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "EndTime", "WinnerId" },
                values: new object[] { new DateTime(2024, 10, 22, 11, 43, 52, 971, DateTimeKind.Local).AddTicks(5846), 0 });

            migrationBuilder.UpdateData(
                table: "BidDb",
                keyColumn: "Id",
                keyValue: -1,
                column: "Date",
                value: new DateTime(2024, 10, 17, 11, 43, 52, 971, DateTimeKind.Local).AddTicks(6144));
        }
    }
}
