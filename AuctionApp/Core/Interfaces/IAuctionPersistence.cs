namespace AuctionApp.Core.Interfaces;

public interface IAuctionPersistence
{
    List<Auction> GetOngoingAuctions();
    
    Auction GetAuctionById(int id);
    
    List<Auction> GetOngoingAuctionsByBidUserid(string id);
    
    List<Auction> GetWonAuctionsByUserId(string id);
    
    void AddAuction(Auction auction);
    
    void AddBid(Bid bid
    );
    List<Auction> GetAuctionsByUserId(string id);
}