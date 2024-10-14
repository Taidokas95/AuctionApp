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

    public void AddBid(Bid bid)
    {
        if (_bids.Contains(bid))
        {
            var currentHighestBid = _bids[_bids.Count - 1];
            if (bid.BidAmount > currentHighestBid.BidAmount)
            {
                _bids.Add(bid);

            }
            else
            {
                throw new Exception("The amount must be higher than the current highest bid");
            }
        }
        _bids.Add(bid);
    }

    public int DetermineWinner()
    {
        var currentHighestBid = _bids[_bids.Count - 1];
        return currentHighestBid.UserID;
    }

    public void EditDescription(string newDescription)
    {
        this.AuctionDescription = newDescription;
    }

   
}