using HackerNewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackerNewsAPI.Managers
{
    public interface IItemCachingHelper
    {
        public bool TryGetItem(int itemId, out Item item);

        public void AddItem(Item item);
    }
}
