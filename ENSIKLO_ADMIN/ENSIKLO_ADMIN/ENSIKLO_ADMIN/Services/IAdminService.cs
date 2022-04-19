using ENSIKLO_ADMIN.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace ENSIKLO_ADMIN.Services
{
    public interface IAdminService
    {
        Task<bool> AddAdminAsync(Admin item);
        Task<string> LoginAdminAsync(LoginRequest loginRequest);
        Task<bool> UpdateAdminAsync(Admin item);
        Task<bool> DeleteAdminAsync(Int64 id);
        Task<Admin> GetAdminAsync(Int64 id);
        Task<Admin> GetCurrentAdmin();
        Task<IEnumerable<Admin>> GetAdminsAsync(bool forceRefresh = false);
    }
}
