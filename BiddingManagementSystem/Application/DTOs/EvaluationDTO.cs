namespace BiddingManagementSystem.Application.DTOs
{
    public class EvaluationDTO
    {
        public int Id { get; set; }
        public int BidId { get; set; }
        public int EvaluatorId { get; set; }
        public int Score { get; set; }
        public string Comments { get; set; }
    }
}
