using AuctionApp.Core.Interfaces;

namespace AuctionApp.Persistence;

public class MySqlAuctionPersistence : IAuctionPersistence
{
    private AuctionDbContext dbContext;

    public AuctionSqlPersistence(AuctionDbContext dbContext)
    {
        _dbContext = dbContext;
    }

}