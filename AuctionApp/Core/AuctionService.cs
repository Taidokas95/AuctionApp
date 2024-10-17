using System.Data;
using System.Runtime.InteropServices.JavaScript;
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

        if (auction == null)
        {
            throw new Exception("No auction found with id: " + id);
        }

        return auction;
    }

    public List<Auction> GetOngoingAuctionsByBidUserid(string id)
    {
        List<Auction> result = _auctionPersistence.GetOngoingAuctionsByBidUserid(id);

        if (!result.Any())
        {
            throw new Exception("No auctions found");
        }

        return result;
    }


    public List<Auction> GetWonAuctionsByUserId(string id)
    {
        List<Auction> result = _auctionPersistence.GetWonAuctionsByUserId(id);

        if (!result.Any())
        {
            throw new Exception("No won auctions found");
        }

        return result;
    }


    public void AddAuction(string userId, string name, string description, int price)
    {
        if (userId == null) throw new DataException("UserId cannot be null");
        if (name == null) throw new DataException("Auction name is missing");
        if (description == null) throw new DataException("Auction description is missing");
        if (price < 0 || price == null) throw new DataException("Price cannot be negative");

        Auction auction = new Auction(name, description, price, userId, DateTime.Now.AddDays(14));
        _auctionPersistence.AddAuction(auction);
    }


    public void AddBid(int amount, string userId, int auctionId)
    {
        var auction = GetAuctionById(auctionId);

        if (!auction.Bids.Any())
        {
            if (amount >= auction.StartingPrice)
            {
                Bid bid = new Bid(amount, userId, auctionId);
                auction.AddBid(bid);
                
                _auctionPersistence.AddBid(bid);
            }
            else
            {
                throw new Exception($"The bid amount must be equal to or higher than the starting price.");
            }
        }
        else
        {
            var currentHighestBid = auction.Bids.Last();
            if (amount > currentHighestBid.Amount)
            {
                Bid bid = new Bid(amount, userId, auctionId);
                auction.AddBid(bid);
                _auctionPersistence.AddBid(bid);
            }
            else
            {
                throw new Exception("The amount must be higher than the current highest bid.");
            }
        }
    }

    public List<Auction> GetAuctionByUserId(string? identityName)
    {
        List<Auction> result = _auctionPersistence.GetAuctionsByUserId(identityName);
        {
            if (!result.Any())
            {
                throw new Exception("No auctions found");
            }

            return result;
        }
    }
}