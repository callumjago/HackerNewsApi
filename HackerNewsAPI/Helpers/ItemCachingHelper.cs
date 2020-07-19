using HackerNewsAPI.Models;
using System.Collections.Generic;

namespace HackerNewsAPI.Managers
{
    public class ItemCachingHelper : IItemCachingHelper
    {
        #region Fields

        private Dictionary<int, Item> _itemDictionary;

        #endregion

        public ItemCachingHelper()
        {
            _itemDictionary = new Dictionary<int, Item>();
        }

        public void AddItem(Item item)
        {
            if (item == null)
            {
                return;
            }

            if (!_itemDictionary.ContainsKey(item.id))
            {
                _itemDictionary.Add(item.id, item);
            }
        }

        public bool TryGetItem(int itemId, out Item item)
        {
            if (_itemDictionary.TryGetValue(itemId, out item))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
