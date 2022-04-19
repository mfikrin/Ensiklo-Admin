using ENSIKLO_ADMIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENSIKLO_ADMIN.Services
{
    public class DummyUser : IUserService
    {
        readonly List<Admin> users;

        public DummyUser()
        {
            users = new List<Admin>()
            {
                new Admin {Id = 1,Email="fikri@gmail.com",Username="Fikri",Password="Rahasia"},
                new Admin {Id = 2,Email="fikriClone1@gmail.com",Username="Fikri1",Password="Rahasia1"},
                new Admin {Id = 3,Email="fikriClone2@gmail.com",Username="Fikri2",Password="Rahasia2"},
            };
        }
        public async Task<bool> AddUserAsync(Admin item)
        {
            users.Add(item);

            return await Task.FromResult(true);
        }

        public Task<bool> AddUserAsync(User item)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUserAsync(Int64 id)
        {
            var oldItem = users.Where((Admin arg) => arg.Id == id).FirstOrDefault();
            users.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public Task<User> GetCurrentUser()
        {
            throw new NotImplementedException();
        }

        public async Task<Admin> GetUserAsync(Int64 id)
        {
            return await Task.FromResult(users.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Admin>> GetUsersAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(users);
        }

        public Task<string> LoginAsync(LoginRequest loginRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateUserAsync(Admin item)
        {
            var oldItem = users.Where((Admin arg) => arg.Id == item.Id).FirstOrDefault();
            users.Remove(oldItem);
            users.Add(item);

            return await Task.FromResult(true);
        }

        public Task<bool> UpdateUserAsync(User item)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserService.GetUserAsync(long id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<User>> IUserService.GetUsersAsync(bool forceRefresh)
        {
            throw new NotImplementedException();
        }
    }
}
