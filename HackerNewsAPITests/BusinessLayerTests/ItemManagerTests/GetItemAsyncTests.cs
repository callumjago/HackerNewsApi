using HackerNewsAPI.Managers;
using HackerNewsAPI.Models;
using HackerNewsAPI.Repositories;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace HackerNewsAPITests.BusinessLayerTests.ItemManagerTests
{
    public class GetItemAsyncTests
    {
        #region Fields

        private IItemManager _itemManager;
        private Mock<IItemRepository> _mockItemRepository;
        private int _itemId;

        #endregion

        #region TestInitialize

        private void Initialize()
        {
            _mockItemRepository = new Mock<IItemRepository>(MockBehavior.Strict);
            _mockItemRepository.Setup(x => x.GetItemAsync(It.IsAny<int>())).ReturnsAsync(new Item());

            _itemId = 5;

            _itemManager = new ItemManager(_mockItemRepository.Object);
        }

        #endregion

        #region Tests

        [Fact]
        public async Task GetItemAsync_CallMethod_CallsGetItemAsync()
        {
            Initialize();
            await CallMethod();

            _mockItemRepository.Verify(x => x.GetItemAsync(_itemId), Times.Once);
        }

        #endregion

        #region Helpers

        private async Task<Item> CallMethod()
            => await _itemManager.GetItemAsync(_itemId);

        #endregion
    }
}
