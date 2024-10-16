﻿using System.ComponentModel.DataAnnotations;
using AuctionApp.Core;

namespace AuctionApp.Models.Auctions;

public class BidVm
{
    [ScaffoldColumn(false)]
    public int Id { get; set; }
    
    [Display (Name = "Amount")]
    public int Amount { get; set; }
    
    public string UserId { get; set; }
    
    public DateTime Date { get; set; }

    public static BidVm FromBid(Bid bid)
    {
        return new BidVm()
        {
            Id = bid.Id,
            Amount = bid.Amount,
            UserId = bid.userId,
            Date = bid.Date
        };
    }
}