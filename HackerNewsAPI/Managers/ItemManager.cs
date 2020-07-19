using HackerNewsAPI.Models;
using HackerNewsAPI.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNewsAPI.Managers
{
    public class ItemManager : IItemManager
    {
        #region Fields

        private IItemRepository _itemRepository;
        private static IItemCachingHelper _itemCachingHelper = new ItemCachingHelper();

        #endregion

        #region Constructor

        public ItemManager(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        #endregion

        #region Implementation of IItemManager

        // Returns the requested item
        public async Task<Item> GetItemAsync(int itemId)
        {
            return await _itemRepository.GetItemAsync(itemId);
        }

        // Returns a list of new items with the requested paging/search options
        public async Task<List<Item>> GetNewItemsAsync(int page, int pageSize, string titleQuery)
        {
            var itemList = new List<Item>();

            var newIds = await _itemRepository.GetNewItemIdsAsync();

            foreach(var itemId in newIds)
            {
                Item item;
                if (!_itemCachingHelper.TryGetItem(itemId, out item))
                {
                    item = await _itemRepository.GetItemAsync(itemId);
                    _itemCachingHelper.AddItem(item);
                }

                if (item != null)
                {
                    itemList.Add(item);
                }
            }

            if (titleQuery != "")
            {
                itemList = itemList.Where(x => x.title.ToLower().Contains(titleQuery.ToLower())).ToList();
            }

            itemList = itemList.Skip(pageSize * (page-1)).Take(pageSize).ToList();

            return itemList;
        }

        #endregion
    }
}
