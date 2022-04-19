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
        Task<string> LoginAsync(LoginRequest loginRequest);
        Task<bool> UpdateUserAsync(User item);
        Task<bool> DeleteUserAsync(Int64 id);
        Task<User> GetUserAsync(Int64 id);
        Task<User> GetCurrentUser();
        Task<IEnumerable<User>> GetUsersAsync(bool forceRefresh = false);
    }
}
