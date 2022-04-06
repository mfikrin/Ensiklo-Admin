using ENSIKLO_ADMIN.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ENSIKLO_ADMIN.Services
{
    public interface IUserService
    {
        Task<bool> AddUserAsync(User item);
        Task<bool> UpdateUserAsync(User item);
        Task<bool> DeleteUserAsync(int id);
        Task<User> GetUserAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync(bool forceRefresh = false);
    }
}
