﻿// <auto-generated />
using System;
using AuctionApp.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AuctionApp.Migrations
{
    [DbContext(typeof(AuctionDbContext))]
    [Migration("20241017121639_new seed data")]
    partial class newseeddata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AuctionApp.Persistence.AuctionDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("StartingPrice")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("WinnerId")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("AuctionDb");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Description = "Spöke",
                            EndTime = new DateTime(2024, 10, 22, 14, 16, 37, 539, DateTimeKind.Local).AddTicks(6988),
                            Name = "Test: Halloween kostym",
                            StartingPrice = 100,
                            UserId = "hannah.kanjah@gmail.com"
                        },
                        new
                        {
                            Id = -2,
                            Description = "I plast",
                            EndTime = new DateTime(2024, 10, 22, 14, 16, 37, 539, DateTimeKind.Local).AddTicks(7072),
                            Name = "Test: Pumpa",
                            StartingPrice = 150,
                            UserId = "Test2"
                        });
                });

            modelBuilder.Entity("AuctionApp.Persistence.BidDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("AuctionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AuctionId");

                    b.ToTable("BidDb");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Amount = 110,
                            AuctionId = -1,
                            Date = new DateTime(2024, 10, 17, 14, 16, 37, 539, DateTimeKind.Local).AddTicks(7462),
                            UserId = "test2"
                        },
                        new
                        {
                            Id = -2,
                            Amount = 160,
                            AuctionId = -2,
                            Date = new DateTime(2024, 10, 17, 14, 16, 37, 539, DateTimeKind.Local).AddTicks(7472),
                            UserId = "test2"
                        });
                });

            modelBuilder.Entity("AuctionApp.Persistence.BidDb", b =>
                {
                    b.HasOne("AuctionApp.Persistence.AuctionDb", "AuctionDb")
                        .WithMany("BidDbs")
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuctionDb");
                });

            modelBuilder.Entity("AuctionApp.Persistence.AuctionDb", b =>
                {
                    b.Navigation("BidDbs");
                });
#pragma warning restore 612, 618
        }
    }
}