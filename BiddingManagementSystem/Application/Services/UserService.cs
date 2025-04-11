using BiddingManagementSystem.Application.DTOs;
using BiddingManagementSystem.Application.Interfaces;
using BiddingManagementSystem.Domain.Interfaces;
using BiddingManagementSystem.Domain.Models;

namespace BiddingManagementSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            return new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Role = user.Role
            };
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(user => new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Role = user.Role
            });
        }

        public async Task AddUserAsync(UserDTO userDTO)
        {
            var user = new User
            {
                UserName = userDTO.UserName,
                Email = userDTO.Email,
                Role = userDTO.Role
            };

            await _userRepository.AddAsync(user);
        }

        public async Task UpdateUserAsync(UserDTO userDTO)
        {
            var user = await _userRepository.GetByIdAsync(userDTO.Id);
            if (user == null)
            {
                return;
            }

            user.UserName = userDTO.UserName;
            user.Email = userDTO.Email;
            user.Role = userDTO.Role;

            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }
    }
}
