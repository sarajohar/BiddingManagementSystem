using System.Security.Cryptography;

namespace BiddingManagementSystem.Domain.Models
{
    public class Tender
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public decimal? Budget { get; set; }
        public string Category { get; set; }
        public int? ProcurementOfficerId { get; set; }
        public DateTime? IssueDate { get; set; }
        public string TenderType { get; set; }
        public string Location { get; set; }
        public string ContactEmail { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public User ProcurementOfficer { get; set; }
        public ICollection<Bid> Bids { get; set; }
        public ICollection<TenderDocument> TenderDocuments { get; set; }
    }
}
