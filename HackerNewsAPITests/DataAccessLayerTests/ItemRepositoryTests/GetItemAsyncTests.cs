using HackerNewsAPI.Helpers;
using HackerNewsAPI.Models;
using HackerNewsAPI.Repositories;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace HackerNewsAPITests.DataAccessLayerTests.ItemRepositoryTests
{
    public class GetItemAsyncTests
    {
        #region Fields

        private IItemRepository _itemRepository;
        private Mock<IHttpHelper> _mockHttpHelper;
        private int _itemId;

        #endregion

        #region TestInitialize

        private void Initialize()
        {
            _mockHttpHelper = new Mock<IHttpHelper>(MockBehavior.Strict);
            _mockHttpHelper.Setup(x => x.GetAsync<Item>(It.IsAny<string>())).ReturnsAsync(new Item());

            _itemRepository = new ItemRepository(_mockHttpHelper.Object);
        }

        #endregion

        #region Tests

        [Fact]
        public async Task GetItemAsync_CallMethod_CallsGetAsync()
        {
            Initialize();
            await CallMethod();

            _mockHttpHelper.Verify(x => x.GetAsync<Item>($"https://hacker-news.firebaseio.com/v0/item/{_itemId}.json"), Times.Once);
        }

        #endregion

        #region Helpers

        private async Task<Item> CallMethod()
            => await _itemRepository.GetItemAsync(_itemId);

        #endregion
    }
}
