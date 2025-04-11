using BiddingManagementSystem.Application.DTOs;
using BiddingManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BiddingManagementSystem.Controllers
{
        public class UserController : ControllerBase
        {
            private readonly IUserService _userService;

            public UserController(IUserService userService)
            {
                _userService = userService;
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetUser(int id)
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }

            [HttpGet]
            public async Task<IActionResult> GetAllUsers()
            {
                var users = await _userService.GetAllUsersAsync();
                return Ok(users);
            }

            [HttpPost]
            public async Task<IActionResult> AddUser(UserDTO userDTO)
            {
                await _userService.AddUserAsync(userDTO);
                return CreatedAtAction(nameof(GetUser), new { id = userDTO.Id }, userDTO);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateUser(int id, UserDTO userDTO)
            {
                if (id != userDTO.Id)
                {
                    return BadRequest();
                }
                await _userService.UpdateUserAsync(userDTO);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteUser(int id)
            {
                await _userService.DeleteUserAsync(id);
                return NoContent();
            }
        }
    }

