using AuctionApp.Models.Auctions;

namespace AuctionApp.Core.Interfaces;

public interface IAuctionService
{
    List<Auction> GetOngoingAuctions();
    
    Auction GetAuctionById(int id);
    
    List<Auction> GetOngoingAuctionsByBidUserid(string id);
    
    List<Auction> GetWonAuctionsByUserId(string id);
    
    void AddAuction(string userId, string name, string description, int price);
    
    void AddBid(int amount,string userId, int auctionId);

    List<Auction> GetAuctionByUserId(string? identityName);
    
    void UpdateAuction(Auction auction);
   
    void UpdateAuction(int auction, EditVm editVm);
}
