using System.Reflection;
using System.Security.Cryptography;

namespace BiddingManagementSystem.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Tender> Tenders { get; set; }
        public ICollection<Bid> Bids { get; set; }
        public ICollection<Evaluation> Evaluations { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
