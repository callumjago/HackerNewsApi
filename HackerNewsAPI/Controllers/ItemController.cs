using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackerNewsAPI.Managers;
using HackerNewsAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HackerNewsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        #region Fields

        private IItemManager _itemManager;

        #endregion

        public ItemController(IItemManager itemManager)
        {
            _itemManager = itemManager;
        }

        #region Actions

        // GET api/Item/5
        [HttpGet("{id}")]
        public async Task<Item> Get(int id)
        {
            return await _itemManager.GetItemAsync(id);
        }

        // GET api/Item/new
        [HttpGet("new")]
        public async Task<List<Item>> GetNewStories()
        {
            var re = Request;
            var headers = re.Headers;

            var page = 1;
            var pageSize = 20;
            var titleQuery = "";

            if (headers.TryGetValue("page", out var pageValues))
            {
                page = Convert.ToInt32(pageValues.First());
            }

            if (headers.TryGetValue("pageSize", out var pageSizeValues))
            {
                pageSize = Convert.ToInt32(pageSizeValues.First());
            }

            if (headers.TryGetValue("title", out var titleQueryValues))
            {
                titleQuery = titleQueryValues;
            }

            return await _itemManager.GetNewItemsAsync(page, pageSize, titleQuery);
        }

        #endregion
    }
}
