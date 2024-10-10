namespace AuctionApp.Core;

public class Auction
{
    public int AuctionId { get; }
    public string AuctionName { get; }
    public string AuctionDescription { get; set; }
    public int AuctionStartingPrice { get; }
    public int UserId { get; }
    public DateTime AuctionEndDate { get; }
    public int WinnerId { get; set; }
    private List<Bid> _bids = new List<Bid>();
    public IEnumerable<Bid> Bids => _bids;

    public Auction(int id, string name, string description, int startingPrice, int userId, DateTime auctionEndDate)
    {
        this.AuctionId = id;
        this.AuctionName = name;
        this.AuctionDescription = description;
        this.AuctionStartingPrice = startingPrice;
        this.UserId = userId;
        this.AuctionEndDate = auctionEndDate;
    }
}