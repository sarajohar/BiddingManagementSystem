using BiddingManagementSystem.Application.DTOs;
using BiddingManagementSystem.Application.Interfaces;
using BiddingManagementSystem.Domain.Interfaces;
using BiddingManagementSystem.Domain.Models;

namespace BiddingManagementSystem.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<NotificationDTO> GetNotificationByIdAsync(int id)
        {
            var notification = await _notificationRepository.GetByIdAsync(id);
            return notification == null ? null : MapToDTO(notification);
        }

        public async Task<IEnumerable<NotificationDTO>> GetAllNotificationsAsync()
        {
            var notifications = await _notificationRepository.GetAllAsync();
            return notifications.Select(MapToDTO);
        }

        public async Task AddNotificationAsync(NotificationDTO notificationDTO)
        {
            var notification = MapToEntity(notificationDTO);
            await _notificationRepository.AddAsync(notification);
            notificationDTO.Id = notification.Id;
        }

        public async Task UpdateNotificationAsync(NotificationDTO notificationDTO)
        {
            var existingNotification = await _notificationRepository.GetByIdAsync(notificationDTO.Id);
            if (existingNotification != null)
            {
                var updatedNotification = MapToEntity(notificationDTO, existingNotification);
                await _notificationRepository.UpdateAsync(updatedNotification);
            }
        }

        public async Task DeleteNotificationAsync(int id)
        {
            await _notificationRepository.DeleteAsync(id);
        }

        private NotificationDTO MapToDTO(Notification notification)
        {
            return new NotificationDTO
            {
                Id = notification.Id,
                UserId = notification.UserId,
                Message = notification.Message,
                DateSent = notification.DateSent,
                IsRead = notification.IsRead
            };
        }

        private Notification MapToEntity(NotificationDTO notificationDTO, Notification existingNotification = null)
        {
            var notification = existingNotification ?? new Notification();
            notification.UserId = notificationDTO.UserId;
            notification.Message = notificationDTO.Message;
            notification.DateSent = notificationDTO.DateSent;
            notification.IsRead = notificationDTO.IsRead;
            return notification;
        }
    }
}
