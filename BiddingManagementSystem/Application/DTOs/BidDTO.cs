namespace BiddingManagementSystem.Application.DTOs
{
    public class BidDTO
    {
        public int Id { get; set; }
        public int TenderId { get; set; }
        public int BidderId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
    }
}
