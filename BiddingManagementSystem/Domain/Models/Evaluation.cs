namespace BiddingManagementSystem.Domain.Models
{
    public class Evaluation
    {
        public int Id { get; set; }
        public int BidId { get; set; }
        public int EvaluatorId { get; set; }
        public int Score { get; set; }
        public string Comments { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Bid Bid { get; set; }
        public User Evaluator { get; set; }
    }
}
