using HackerNewsAPI.Helpers;
using HackerNewsAPI.Models;
using HackerNewsAPI.Repositories;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace HackerNewsAPITests.DataAccessLayerTests.ItemRepositoryTests
{
    public class GetNewItemIdsAsyncTests
    {
        #region Fields

        private IItemRepository _itemRepository;
        private Mock<IHttpHelper> _mockHttpHelper;

        #endregion

        #region TestInitialize

        private void Initialize()
        {
            _mockHttpHelper = new Mock<IHttpHelper>(MockBehavior.Strict);
            _mockHttpHelper.Setup(x => x.GetAsync<List<int>>(It.IsAny<string>())).ReturnsAsync(new List<int>());

            _itemRepository = new ItemRepository(_mockHttpHelper.Object);
        }

        #endregion

        #region Tests

        [Fact]
        public async Task GetNewItemIdsAsync_CallMethod_CallsGetAsync()
        {
            Initialize();
            await CallMethod();

            _mockHttpHelper.Verify(x => x.GetAsync<List<int>>("https://hacker-news.firebaseio.com/v0/newstories.json"), Times.Once);
        }

        #endregion

        #region Helpers

        private async Task<List<int>> CallMethod()
            => await _itemRepository.GetNewItemIdsAsync();

        #endregion
    }
}
