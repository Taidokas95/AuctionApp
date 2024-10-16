using AuctionApp.Core.Interfaces;

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
        return _auctions.FindAll(auction => auction.EndTime > DateTime.Now);
    }

    public Auction GetAuctionById(int id)
    {
         return _auctions.Find(auction => auction.Id == id);
    }

    public List<Auction> GetOngoingAuctionsByBidUserid(int id)
    {
        var a = GetOngoingAuctions();
        var matchingAuctions = new List<Auction>();
        foreach (var auction in a)
        {
            if (GetBidsByUserId(id, auction))
            {
                matchingAuctions.Add(auction);
            }
        }

        return matchingAuctions;
    }

    private bool GetBidsByUserId(int id, Auction auction)
    {
        var userIdPresent = 0;
        foreach (var bid in auction.Bids)
        {
            if (bid.UserID == id)
            {
                userIdPresent++;
            }
        }

        return userIdPresent > 0;
    }

    public List<Auction> GetWonAuctionsByUserId(int Id)
    {
        return CompletedAuctions().FindAll(auction => Id == auction.WinnerId);
        
    }

    private List<Auction> CompletedAuctions()
    {
        return _auctions.FindAll(auction => auction.EndTime > DateTime.Now);
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