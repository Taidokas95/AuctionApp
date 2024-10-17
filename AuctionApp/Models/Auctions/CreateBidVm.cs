using Microsoft.Build.Framework;

namespace AuctionApp.Models;

public class CreateBidVm
{
    [Required]
    public int amount { get; set; }
    
}