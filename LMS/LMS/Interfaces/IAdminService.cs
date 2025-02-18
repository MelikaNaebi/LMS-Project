using LMS.Dto;
using LMS.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task CreateUserAsync(UserDto userDto);
        Task<bool> UpdateUserAsync(int id, UserDto userDto);
        Task<bool> DeleteUserAsync(int id);
    }
}
