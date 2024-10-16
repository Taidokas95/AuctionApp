using AuctionApp.Core.Interfaces;
using Humanizer;

namespace AuctionApp.Core;

public class AuctionService : IAuctionService
{
    private readonly IAuctionPersistence _auctionPersistence;

    public AuctionService(IAuctionPersistence auctionPersistence)
    {
        _auctionPersistence = auctionPersistence;
    }
    
    public List<Auction> GetOngoingAuctions()
    {
        List<Auction> ongoingAuctions = _auctionPersistence.GetOngoingAuctions();
        return ongoingAuctions;
    }

    public Auction GetAuctionById(int id)
    {
        Auction auction = _auctionPersistence.GetAuctionById(id);
        return auction;
    }

    public List<Auction> GetOngoingAuctionsByBidUserid(int id)
    {
        return _auctionPersistence.GetOngoingAuctionsByBidUserid(id);
    }
    

    public List<Auction> GetWonAuctionsByUserId(int Id)
    {
        return _auctionPersistence.GetWonAuctionsByUserId(Id);
    }

    public void AddAuction(Auction auction)
    {
        _auctions.Add(auction);
    }
    
    
    public void AddBid(Bid bid, int auctionId)
    {
        var auction = GetAuctionById(auctionId);
        
        if (!auction.Bids.Any())
        {
            if (bid.Amount >= auction.StartingPrice)
            {
                auction.AddBid(bid);
            }
            else
            {
                throw new Exception($"The bid amount must be equal to or higher than the starting price.");
            }
        }
        else
        {
            var currentHighestBid = auction.Bids.Last();
            if (bid.Amount > currentHighestBid.Amount)
            {
                auction.AddBid(bid);
            }
            else
            {
                throw new Exception("The amount must be higher than the current highest bid.");
            }
        }
    }


    private static readonly List<Auction> _auctions = new();

    static AuctionService()
    {
        Auction a1 = new Auction(1, "auction1", "Antique bookshelf", 3000, 1, DateTime.Now.AddDays(7));
        Auction a2 = new Auction(2, "auction2", "Tea set", 1000, 1, DateTime.Now.AddDays(8));
        Auction a3 = new Auction(3, "auction3", "Wooden table", 2000, 2, DateTime.Now.AddDays(5));

        a1.AddBid(new Bid(1, 3500, 2, DateTime.Now));
        a3.AddBid(new Bid(2, 2300, 1, DateTime.Now.AddDays(1)));

        _auctions.Add(a1);
        _auctions.Add(a2);
        _auctions.Add(a3);
    }
}