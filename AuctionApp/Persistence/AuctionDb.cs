using System.ComponentModel.DataAnnotations;
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
    
    public int WinnerId { get; set; }
    
    [Required] 
    public int UserId { get; set; }
    
    public List<BidDb> BidDbs { get; set; }
    
   
}