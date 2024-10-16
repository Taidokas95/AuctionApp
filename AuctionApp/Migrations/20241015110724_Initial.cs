using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace AuctionApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AuctionDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    StartingPrice = table.Column<int>(type: "int", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    WinnerId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionDb", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BidDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AuctionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BidDb_AuctionDb_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "AuctionDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AuctionDb",
                columns: new[] { "Id", "Description", "EndTime", "Name", "StartingPrice", "UserId", "WinnerId" },
                values: new object[] { -1, "Auction Description", new DateTime(2024, 10, 20, 13, 7, 23, 410, DateTimeKind.Local).AddTicks(3066), "Auction -1", -1, -1, 0 });

            migrationBuilder.InsertData(
                table: "BidDb",
                columns: new[] { "Id", "Amount", "AuctionId", "Date", "UserId" },
                values: new object[] { -1, -1, -1, new DateTime(2024, 10, 15, 13, 7, 23, 410, DateTimeKind.Local).AddTicks(3291), -2 });

            migrationBuilder.CreateIndex(
                name: "IX_BidDb_AuctionId",
                table: "BidDb",
                column: "AuctionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BidDb");

            migrationBuilder.DropTable(
                name: "AuctionDb");
        }
    }
}
