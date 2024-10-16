namespace AuctionApp.Core;

public class Bid
{
    public int Id { get; }
    public int Amount { get; }
    public int UserID { get; }
    public DateTime Date { get; }

    public Bid(int id, int amount, int userID, DateTime date)
    {
        this.Id = id;
        this.Amount = amount;
        this.UserID = userID;
        this.Date = date;
    }
}