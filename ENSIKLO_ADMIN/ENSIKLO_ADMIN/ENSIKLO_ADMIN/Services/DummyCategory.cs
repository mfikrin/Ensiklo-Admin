using ENSIKLO_ADMIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENSIKLO_ADMIN.Services
{
    public class DummyCategory : ICatService
    {
        readonly List<Category> categories;

        public DummyCategory()
        {
            categories = new List<Category>()
            {
                new Category {Id_cat = 1,Cat_name="Science"},
                new Category {Id_cat = 1,Cat_name="Fiction"},
                new Category {Id_cat = 1,Cat_name="Romance"},
            };
        }
        public async Task<bool> AddCatAsync(Category item)
        {
            categories.Add(item);
            return await Task.FromResult(true);

        }

        public async Task<Category> GetCatAsync(int id)
        {
            return await Task.FromResult(categories.FirstOrDefault(s => s.Id_cat == id));
       
        }

        public async Task<IEnumerable<Category>> GetCatsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(categories);
        }
    }
}
