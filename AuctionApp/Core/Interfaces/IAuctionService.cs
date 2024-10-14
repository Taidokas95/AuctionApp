namespace AuctionApp.Core.Interfaces;

public interface IAuctionService
{
    List<Auction> GetOngoingAuctions();
    
    Auction GetAuctionById(int id);
    
    List<Auction> GetOngoingAuctionsByBidUserid(int id);
    
    List<Auction> GetWonAuctionsByUserId(int id);
    
    void AddAuction(Auction auction);
    
    void AddBid(Bid bid);
    
}
