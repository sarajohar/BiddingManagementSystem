using BiddingManagementSystem.Domain.Models;

namespace BiddingManagementSystem.Domain.Interfaces
{
    public interface INotificationRepository
    {
        Task<Notification> GetByIdAsync(int id);
        Task<IEnumerable<Notification>> GetAllAsync();
        Task AddAsync(Notification notification);
        Task UpdateAsync(Notification notification);
        Task DeleteAsync(int id);
    }
}
