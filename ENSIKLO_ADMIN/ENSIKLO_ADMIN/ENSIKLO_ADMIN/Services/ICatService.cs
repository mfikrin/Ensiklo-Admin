using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ENSIKLO_ADMIN.Models;

namespace ENSIKLO_ADMIN.Services
{
    public interface ICatService
    {
        Task<bool> AddCatAsync(Category item);
        Task<Category> GetCatAsync(int id);
        Task<IEnumerable<Category>> GetCatsAsync(bool forceRefresh = false);
    }
}
