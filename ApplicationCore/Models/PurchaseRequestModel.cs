using System;

namespace ApplicationCore.Models
{
    public class PurchaseRequestModel
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }

        // ⭐ Added so the purchase page can show movie details
        public string Title { get; set; }
        public string PosterUrl { get; set; }
    }
}
