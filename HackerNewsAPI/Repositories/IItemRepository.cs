using HackerNewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNewsAPI.Repositories
{
    public interface IItemRepository
    {
        public Task<Item> GetItemAsync(int itemId);

        public Task<List<int>> GetNewItemIdsAsync();
    }
}
