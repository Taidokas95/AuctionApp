using AuctionApp.Core;
using AuctionApp.Core.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuctionApp.Persistence;

public class MySqlAuctionPersistence : IAuctionPersistence
{
    private readonly AuctionDbContext _dbContext;
    private readonly IMapper _mapper;

    public MySqlAuctionPersistence(AuctionDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public List<Auction> GetOngoingAuctions()
    {
        var auctionDbs = _dbContext.AuctionDb.
            Where(a => a.EndTime > DateTime.Now).
            Include(a => a.BidDbs).ToList();
        
        List<Auction> result = new List<Auction>();
        foreach (AuctionDb adb in auctionDbs)
        {
            Auction auction = _mapper.Map<Auction>(adb);
            result.Add(auction);
        }
        return result;
    }

    public Auction GetAuctionById(int id)
    {
        var auctionDb = _dbContext.AuctionDb.SingleOrDefault(a => a.Id == id);
        
        Auction auction = _mapper.Map<Auction>(auctionDb);
        return auction;
    }

    public List<Auction> GetOngoingAuctionsByBidUserid(string id)
    {
        var auctionDbs = _dbContext.AuctionDb.Where(a => a.BidDbs.Any(b => b.UserId == id)).Include(a => a.BidDbs).ToList();
        
        List<Auction> result = new List<Auction>();
        foreach (AuctionDb adb in auctionDbs)
        {
            Auction auction = _mapper.Map<Auction>(adb);
            result.Add(auction);
        }
        
        return result;
    }

    public List<Auction> GetWonAuctionsByUserId(string id)
    {   
        
        var auctionDbs = _dbContext.AuctionDb.Where(a => a.WinnerId.Equals(id)).ToList();
        List<Auction> result = new List<Auction>();
        foreach (AuctionDb adb in auctionDbs)
        {
            Auction auction = _mapper.Map<Auction>(adb);
            result.Add(auction);
        }
        
        return result;
    }

    public List<Auction> GetAuctionsByUserId(string id)
    {
        var auctionDbs = _dbContext.AuctionDb.Where(a => a.UserId.Equals(id)).ToList();
        List<Auction> result = new List<Auction>();
        foreach (AuctionDb adb in auctionDbs)
        {
            Auction auction = _mapper.Map<Auction>(adb);
            result.Add(auction);
        }
        return result;
    }

    public void AddAuction(Auction auction)
    {
        AuctionDb adb = _mapper.Map<AuctionDb>(auction);
        _dbContext.AuctionDb.Add(adb);
        _dbContext.SaveChanges();
    }

    public void AddBid(Bid bid, int auctionId)
    {
        throw new NotImplementedException();
    }

    
}