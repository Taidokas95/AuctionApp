using AuctionApp.Core;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Persistence;

public class AuctionDbContext : DbContext
{
    public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options) { }
    
    public DbSet<BidDb> BidDb { get; set; }
    public DbSet<AuctionDb> AuctionDb { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        AuctionDb adb1 = new AuctionDb
        {
            Id = -1,
            Name = "Test: Halloween kostym",
            Description = "Spöke",
            StartingPrice = 100,
            EndTime = DateTime.Now.AddDays(5),
            UserId = "celagervall@gmail.com",
            BidDbs = new List<BidDb>()
        };
        AuctionDb adb2 = new AuctionDb
        {
            Id = -2,
            Name = "Test: Pumpa",
            Description = "I plast",
            StartingPrice = 150,
            EndTime = DateTime.Now.AddDays(5),
            UserId = "Test2",
            BidDbs = new List<BidDb>()
        };
    
        AuctionDb adb3 = new AuctionDb
        {
            Id = -3,
            Name = "Test: Taklampa",
            Description = "I Kristall",
            StartingPrice = 5000,
            EndTime = new DateTime(2024, 6, 25),
            UserId = "Test2",
            WinnerId = "celagervall@gmail.com",  // Winner is set here
            BidDbs = new List<BidDb>()
        };
    
        // Include all auctions in the seed data
        modelBuilder.Entity<AuctionDb>().HasData(adb1, adb2, adb3);  // Added adb3 here

        BidDb bdb1 = new BidDb()
        {
            Id = -1,
            Amount = 110,
            Date = DateTime.Now,
            UserId = "test2",
            AuctionId = -1,
        };
        BidDb bdb2 = new BidDb()
        {
            Id = -2,
            Amount = 160,
            Date = DateTime.Now,
            UserId = "celagervall@gmail.com",
            AuctionId = -2,
        };
    
        BidDb bdb3 = new BidDb()
        {
            Id = -3,
            Amount = 5500,
            Date = new DateTime(2024, 6, 20),
            UserId = "celagervall@gmail.com",
            AuctionId = -3,
        };
    
        // Include all bids in the seed data
        modelBuilder.Entity<BidDb>().HasData(bdb1, bdb2, bdb3);  // Added bdb3 here
    }

    
}