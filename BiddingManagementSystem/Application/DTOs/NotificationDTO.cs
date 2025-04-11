namespace BiddingManagementSystem.Application.DTOs
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public DateTime DateSent { get; set; }
        public bool IsRead { get; set; }
    }
}
