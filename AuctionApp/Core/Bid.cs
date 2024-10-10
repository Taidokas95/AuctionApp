namespace AuctionApp.Core;

public class Bid
{
    public int BidID { get; }
    public int BidAmount { get; }
    public int UserID { get; }
    public DateTime Date { get; }

    public Bid(int bidID, int bidAmount, int userID, DateTime date)
    {
        this.BidID = bidID;
        this.BidAmount = bidAmount;
        this.UserID = userID;
        this.Date = date;
    }
}