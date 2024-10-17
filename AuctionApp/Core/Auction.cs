namespace AuctionApp.Core;

public class Auction
{
    public int Id { get; }
    public string Name { get; }
    public string Description { get; set; }
    public int StartingPrice { get; }
    public string UserId { get; }
    public DateTime EndTime { get; }
    public string WinnerId { get; set; }
    private List<Bid> _bids = new List<Bid>();
    public IEnumerable<Bid> Bids => _bids;
    
    public Auction(int id, string name, string description, int startingPrice, string userId, DateTime endTime)
    {
        this.Id = id;
        this.Name = name;
        this.Description = description;
        this.StartingPrice = startingPrice;
        this.UserId = userId;
        this.EndTime = endTime;
        this.WinnerId = "test";
    }

    public Auction(string name, string description, int startingPrice, string userId, DateTime endTime)
    {
        //this.Id = 0;
        this.Name = name;
        this.Description = description;
        this.StartingPrice = startingPrice;
        this.UserId = userId;
        this.EndTime = endTime;
        this.WinnerId = "test";
    }
    

    public void AddBid(Bid bid)
    {
        if (_bids.Contains(bid))
        {
            var currentHighestBid = _bids[_bids.Count - 1];
            if (bid.Amount > currentHighestBid.Amount)
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

    public string DetermineWinner()
    {
        var currentHighestBid = _bids[_bids.Count - 1];
        return currentHighestBid.userId;
    }

    public void EditDescription(string newDescription)
    {
        this.Description = newDescription;
    }

   
}