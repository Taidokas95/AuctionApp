﻿namespace AuctionApp.Core;

public class Bid
{
    public int Id { get; }
    public int Amount { get; }
    public string userId { get; }
    public DateTime Date { get; }

    public Bid(int id, int amount, string userId, DateTime date)
    {
        this.Id = id;
        this.Amount = amount;
        this.userId = userId;
        this.Date = date;
    }
}