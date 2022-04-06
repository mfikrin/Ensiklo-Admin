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
        readonly List<User> users;

        public DummyUser()
        {
            users = new List<User>()
            {
                new User {Id_user = 1,Email="fikri@gmail.com",Username="Fikri",Password="Rahasia",Role="admin"},
                new User {Id_user = 2,Email="fikriClone1@gmail.com",Username="Fikri1",Password="Rahasia1",Role="user"},
                new User {Id_user = 3,Email="fikriClone2@gmail.com",Username="Fikri2",Password="Rahasia2",Role="user"},
            };
        }
        public async Task<bool> AddUserAsync(User item)
        {
            users.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var oldItem = users.Where((User arg) => arg.Id_user == id).FirstOrDefault();
            users.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await Task.FromResult(users.FirstOrDefault(s => s.Id_user == id));
        }

        public async Task<IEnumerable<User>> GetUsersAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(users);
        }

        public async Task<bool> UpdateUserAsync(User item)
        {
            var oldItem = users.Where((User arg) => arg.Id_user == item.Id_user).FirstOrDefault();
            users.Remove(oldItem);
            users.Add(item);

            return await Task.FromResult(true);
        }
    }
}
