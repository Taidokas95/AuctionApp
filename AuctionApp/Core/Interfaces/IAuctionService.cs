namespace AuctionApp.Core.Interfaces;

public interface IAuctionService
{
    List<Auction> GetOngoingAuctions();
    
    Auction GetAuctionById(int id);
    
    List<Auction> GetOngoingAuctionsByBidUserid(string id);
    
    List<Auction> GetWonAuctionsByUserId(string id);
    
    void AddAuction(string userId, string name, string description, int price);
    
    void AddBid(Bid bid, int auctionId);
    
}
