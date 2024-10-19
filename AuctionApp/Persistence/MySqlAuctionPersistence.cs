using AuctionApp.Core;
using AuctionApp.Core.Interfaces;
using AuctionApp.Models.Auctions;
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
            Where(a => a.EndTime > DateTime.Now).ToList();
        
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
        var auctionDb = _dbContext.AuctionDb
            .Where(a => a.Id == id)
            .Include(a => a.BidDbs)
            .SingleOrDefault();
       
        if (auctionDb == null)
        {
            return null;
        }
        Auction auction = _mapper.Map<Auction>(auctionDb);

        if (auctionDb.BidDbs != null)
        {
            foreach (var bidDb in auctionDb.BidDbs)
            {
                Bid bid = _mapper.Map<Bid>(bidDb);
                auction.AddBid(bid);
            }
        }

        return auction;
    }

    public List<Auction> GetOngoingAuctionsByBidUserid(string id)
    {
        var auctionDbs = _dbContext.AuctionDb.Where(a => a.BidDbs.Any(b => b.UserId == id)).ToList();
        
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

    public void UpdateAuction(Auction auction)
    {
        // Detach previously tracked instances of the same entity
        var existingEntity = _dbContext.AuctionDb.FirstOrDefault(a => a.Id == auction.Id);
    
        if (existingEntity != null)
        {
            _dbContext.Entry(existingEntity).State = EntityState.Detached;
        }
        
        AuctionDb adb = _mapper.Map<AuctionDb>(auction);
        
        _dbContext.AuctionDb.Attach(adb);
    
        _dbContext.Entry(adb).State = EntityState.Modified;

        _dbContext.SaveChanges();
    }

    public void UpdateAuction(int auction, EditVm editVm)
    {
        AuctionDb adb = _mapper.Map<AuctionDb>(auction);
        _dbContext.AuctionDb.Update(adb);
        _dbContext.SaveChanges();
    }


    public void AddAuction(Auction auction)
    {
        AuctionDb adb = _mapper.Map<AuctionDb>(auction);
        _dbContext.AuctionDb.Add(adb);
        _dbContext.SaveChanges();
    }

    public void AddBid(Bid bid)
    {
        BidDb bdb = _mapper.Map<BidDb>(bid);
        _dbContext.BidDb.Add(bdb);
        _dbContext.SaveChanges();
    }
    
}