namespace AuctionApp.Core;

public class Bid
{
    public int Id { get; }
    public int Amount { get; }
    public string UserId { get; }
    public DateTime Date { get; }
    public int AuctionId { get; }

    public Bid(int id, int amount, string userId, DateTime date, int auctionId)
    {
        this.Id = id;
        this.Amount = amount;
        this.UserId = userId;
        this.Date = date;
        this.AuctionId = auctionId;
    }
    public Bid(int amount, string userId, int auctionId)
    {
        this.Id = 0;
        this.Amount = amount;
        this.UserId = userId;
        this.Date = DateTime.Now;
        this.AuctionId = auctionId;
    }
}