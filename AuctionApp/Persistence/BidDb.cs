using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AuctionApp.Core;

namespace AuctionApp.Persistence;

public class BidDb
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int Amount { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public string UserId { get; set; }
    
    [ForeignKey("AuctionId")]
    public AuctionDb AuctionDb { get; set; }
    
    public int AuctionId { get; set; }
}