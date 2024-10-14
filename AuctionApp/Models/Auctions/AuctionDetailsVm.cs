using System.ComponentModel.DataAnnotations;
using AuctionApp.Core;

namespace AuctionApp.Models.Auctions;

public class AuctionDetailsVm
{
    [ScaffoldColumn(false)]
    public int Id { get; set; }
    
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
            Id = auction.AuctionId,
            Name = auction.AuctionName,
            Description = auction.AuctionDescription,
            Price = auction.AuctionStartingPrice,
            EndDate = auction.AuctionEndDate
        };
        foreach (var bid in auction.Bids)
        {
            detailsVM.BidVms.Add(BidVm.FromBid(bid));
        }

        return detailsVM;
    }
}