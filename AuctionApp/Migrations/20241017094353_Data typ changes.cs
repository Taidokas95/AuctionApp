using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionApp.Migrations
{
    /// <inheritdoc />
    public partial class Datatypchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BidDb",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AuctionDb",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AuctionDb",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "EndTime", "UserId" },
                values: new object[] { new DateTime(2024, 10, 22, 11, 43, 52, 971, DateTimeKind.Local).AddTicks(5846), "test" });

            migrationBuilder.UpdateData(
                table: "BidDb",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2024, 10, 17, 11, 43, 52, 971, DateTimeKind.Local).AddTicks(6144), "test2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "BidDb",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AuctionDb",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.UpdateData(
                table: "AuctionDb",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "EndTime", "UserId" },
                values: new object[] { new DateTime(2024, 10, 20, 13, 7, 23, 410, DateTimeKind.Local).AddTicks(3066), -1 });

            migrationBuilder.UpdateData(
                table: "BidDb",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2024, 10, 15, 13, 7, 23, 410, DateTimeKind.Local).AddTicks(3291), -2 });
        }
    }
}
