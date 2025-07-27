using Job_Portal.models;
using Job_Portal.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Job_Portal.DTOs;

namespace Job_Portal.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();

            var userDTOs = users.Select(user => new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role.ToString()
            }).ToList();

            return Ok(userDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            var userDetailDTO = new UserDetailDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role.ToString(),

                Jobs = user.Jobs.Select(job => new JobDTO
                {
                    Id = job.Id,
                    Title = job.Title,
                    CompanyName = job.CompanyName,
                    Location = job.Location,
                    Type = job.Type.ToString(),
                    ApplicationsCount = job.ApplicationsCount,
                    PostedDate = job.PostedDate,
                    UserId = job.UserId
                }).ToList(),

                Applications = user.Applications.Select(app => new ApplicationDTO
                {
                    Id = app.Id,
                    ApplicationDate = app.ApplicationDate,
                    Status = app.Status.ToString(),
                    JobId = app.JobId,
                    UserId = app.UserId
                }).ToList()
            };

            return Ok(userDetailDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDTO createUserDTO)
        {
            var newUser = new User
            {
                Name = createUserDTO.Name,
                Email = createUserDTO.Email,
                Password = createUserDTO.Password,
                Role = createUserDTO.Role 
            };

            var createdUser = await _userService.AddUserAsync(newUser);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var user = await _userService.LoginAsync(loginDTO.Email, loginDTO.Password);

            if (user == null)
            {
                return Unauthorized("Invalid credentials.");
            }

            return Ok($"Welcome back, {user.Name}!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User updatedUserData)
        {
            var existingUser = await _userService.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Name = updatedUserData.Name;
            existingUser.Email = updatedUserData.Email;
            existingUser.Role = updatedUserData.Role;

            await _userService.UpdateUserAsync(existingUser);

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
