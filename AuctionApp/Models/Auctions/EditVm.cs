using AuctionApp.Core;
using Microsoft.Build.Framework;

namespace AuctionApp.Models.Auctions

{
    public class EditVm
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public static EditVm FromAuction(Auction auction)
        {
            return new EditVm
            {
                Id = auction.Id,
                Description = auction.Description,
            };
        }

        public Auction ToAuction(Auction auction)
        {
            auction.Description = this.Description;
            return auction;
        }
    }
}
