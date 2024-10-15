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
        AuctionDb adb = new AuctionDb
        {
            Id = -1,
            Name = "Auction -1",
            Description = "Auction Description",
            StartingPrice = -1,
            EndTime = DateTime.Now.AddDays(5),
            UserId = -1,
            BidDbs = new List<BidDb>()
        };
        modelBuilder.Entity<AuctionDb>().HasData(adb);

        BidDb bdb1 = new BidDb()
        {
            Id = -1,
            Amount = -1,
            Date = DateTime.Now,
            UserId = -2,
            AuctionId = -1,
        };
        modelBuilder.Entity<BidDb>().HasData(bdb1);
    }
    
}