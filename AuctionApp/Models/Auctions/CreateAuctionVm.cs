using System.ComponentModel.DataAnnotations;

namespace AuctionApp.Models;

public class CreateAuctionVm
{
    [Required]
    [MinLength(2)]
    public string? name { get; set; }
    
    public string? description { get; set; }
    
    [Required]
    public int price { get; set; }  
}