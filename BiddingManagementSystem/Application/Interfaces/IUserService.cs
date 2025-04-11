using BiddingManagementSystem.Application.DTOs;

namespace BiddingManagementSystem.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task AddUserAsync(UserDTO userDTO);
        Task UpdateUserAsync(UserDTO userDTO);
        Task DeleteUserAsync(int id);
    }
}
