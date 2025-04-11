namespace BiddingManagementSystem.Domain.Models
{
    public class BidDocument
    {
        public int Id { get; set; }
        public int BidId { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadedAt { get; set; }
        public string FileName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Bid Bid { get; set; }
    }
}
