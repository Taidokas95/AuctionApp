using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using AuctionApp.Core;

namespace AuctionApp.Persistence;

public class AuctionDb
{
    [Key]
    public int Id { get; set; }
   
    [Required]
    public string Name { get; set; }
   
    public string Description { get; set; }
    
    [Required]
    public int StartingPrice { get; set; }
    
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime EndTime { get; set; }
    
    public string? WinnerId { get; set; }
    
    [Required] 
    public string UserId { get; set; }
    
    public List<BidDb> BidDbs { get; set; }
    
   
}