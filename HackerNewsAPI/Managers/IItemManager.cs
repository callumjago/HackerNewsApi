using HackerNewsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackerNewsAPI.Managers
{
    public interface IItemManager
    {
        // Returns the requested item
        public Task<Item> GetItemAsync(int itemId);

        // Returns a list of new items with the requested paging/search options
        public Task<List<Item>> GetNewItemsAsync(int page, int pageSize, string titleQuery);
    }
}
