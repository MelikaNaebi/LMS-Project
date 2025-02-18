using LMS.Interfaces;
using LMS.Models;
using LMS.Dto;
using LMS.Repositores;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LMS.Dto;

namespace LMS.Services
{
    public class AdminService : IAdminService
    {
        private readonly IGenericRepository<User> _userRepository;

        public AdminService(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Phone = u.Phone
            });
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone
            };
        }

        public async Task CreateUserAsync(UserDto userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Phone = userDto.Phone,
                
            };

            await _userRepository.AddAsync(user);
        }

        public async Task<bool> UpdateUserAsync(int id, UserDto userDto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return false;

            user.Name = userDto.Name;
            user.Email = userDto.Email;
            user.Phone = userDto.Phone;

            await _userRepository.UpdateAsync(user);
            return true;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return false;

            await _userRepository.DeleteAsync(id);
            return true;
        }
    }
}
