using AuctionApp.Core.Interfaces;

namespace AuctionApp.Core;

public class AuctionService : IAuctionService
{
    public List<Auction> GetOngoingAuctions()
    {
        return _auctions.FindAll(auction => auction.AuctionEndDate < DateTime.Now);
    }

    public Auction GetAuctionById(int id)
    {
        var a = _auctions.Find(auction => auction.AuctionId == id);
        if (a != null)
        {
            return a;
        }

        throw new Exception("Auction Not Found");
    }

    public List<Auction> GetOngoingAuctionsByBidUserid(int id)
    {
        var a = GetOngoingAuctions();
        List<Auction> matchingAuctions = new List<Auction>();
        foreach (var auction in a)
        {
            if (GetBidsByUserId(id, auction))
            {
                matchingAuctions.Add(auction);
            }
        }

        return matchingAuctions;
    }

    public bool GetBidsByUserId(int id, Auction auction)
    {
        var userIdpresent = 0;
        foreach (var bid in auction.Bids)
        {
            if (bid.UserID == id)
            {
                userIdpresent++;
            }
        }

        return userIdpresent > 0;
    }

    public List<Auction> GetWonAuctionsByUserId()
    {
        throw new NotImplementedException();
    }

    public void AddAuction(Auction auction)
    {
        throw new NotImplementedException();
    }

    public void AddBid(Bid bid)
    {
        throw new NotImplementedException();
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