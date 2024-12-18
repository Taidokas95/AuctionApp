﻿using System.ComponentModel.DataAnnotations;
using AuctionApp.Core;
using AuctionApp.Models.Auctions;

namespace AuctionApp.Models.Auctions;

public class AuctionDetailsVm
{
    [ScaffoldColumn(false)]
    public int Id { get; set; }
    
    public string UserId { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public int Price { get; set; }
    
    [Display(Name = "EndDate")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
    
    public DateTime EndDate { get; set; }

    public List<BidVm> BidVms { get; set; } = new();
    
    public static AuctionDetailsVm FromAuction(Auction auction)
    {
        var detailsVM = new AuctionDetailsVm()
        {
            Id = auction.Id,
            UserId = auction.UserId,
            Name = auction.Name,
            Description = auction.Description,
            Price = auction.StartingPrice,
            EndDate = auction.EndTime
        };
        
        foreach (var bid in auction.Bids)
        {
            detailsVM.BidVms.Add(BidVm.FromBid(bid));
        }

        detailsVM.BidVms.Reverse();

        return detailsVM;
    }
}