using HackerNewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using HackerNewsAPI.Helpers;

namespace HackerNewsAPI.Repositories
{
    public class ItemRepository : IItemRepository
    {
        #region Fields

        private IHttpHelper _httpHelper;

        #endregion

        public ItemRepository(IHttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public async Task<Item> GetItemAsync(int itemId)
        {
            var item = await _httpHelper.GetAsync<Item>($"https://hacker-news.firebaseio.com/v0/item/{itemId}.json");

            return item;
        }

        public async Task<List<int>> GetNewItemIdsAsync()
        {
            var newIds = await _httpHelper.GetAsync<List<int>>("https://hacker-news.firebaseio.com/v0/newstories.json");

            return newIds;
        }
    }
}
