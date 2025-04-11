namespace BiddingManagementSystem.Application.DTOs
{
    public class TenderDTO
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
    }
}
