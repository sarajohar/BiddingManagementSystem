namespace BiddingManagementSystem.Domain.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public int TenderId { get; set; }
        public int BidderId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime SubmittedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Tender Tender { get; set; }
        public User Bidder { get; set; }
        public ICollection<Evaluation> Evaluations { get; set; }
        public ICollection<BidDocument> BidDocuments { get; set; }
    }
}
