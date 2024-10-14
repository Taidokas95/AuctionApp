using System.ComponentModel.DataAnnotations;
using AuctionApp.Core;

namespace AuctionApp.Models.Auctions;

public class AuctionVm {
    [ScaffoldColumn(false)]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public int Price { get; set; }
    
    [Display(Name = "EndDate")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
    
    public DateTime EndDate { get; set; }

    public static AuctionVm FromAuction(Auction auction)
    {
        return new AuctionVm()
        {
            Id = auction.AuctionId,
            Name = auction.AuctionName,
            Description = auction.AuctionDescription,
            Price = auction.AuctionStartingPrice,
            EndDate = auction.AuctionEndDate
        };
    }
}