using BiddingManagementSystem.Application.DTOs;

namespace BiddingManagementSystem.Application.Interfaces
{
    public interface INotificationService
    {

        Task<NotificationDTO> GetNotificationByIdAsync(int id);
        Task<IEnumerable<NotificationDTO>> GetAllNotificationsAsync();
        Task AddNotificationAsync(NotificationDTO notificationDTO);
        Task UpdateNotificationAsync(NotificationDTO notificationDTO);
        Task DeleteNotificationAsync(int id);
    }
}
