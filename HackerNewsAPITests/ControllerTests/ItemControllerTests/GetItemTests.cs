using HackerNewsAPI.Controllers;
using HackerNewsAPI.Managers;
using HackerNewsAPI.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HackerNewsAPITests.ControllerTests.ItemControllerTests
{
    public class GetItemTests
    {
        #region Fields

        private ItemController _itemController;
        private Mock<IItemManager> _mockItemManager;

        private int _itemId;

        #endregion

        #region TestInitialize

        private void Initialize()
        {
            _itemId = 5;
            _mockItemManager = new Mock<IItemManager>(MockBehavior.Strict);
            _mockItemManager.Setup(x => x.GetItemAsync(It.IsAny<int>())).ReturnsAsync(new Item());

            _itemController = new ItemController(_mockItemManager.Object);
        }

        #endregion

        #region Tests

        [Fact]
        public async Task GetNewStories_CallMethod_CallsGetNewItemsAsync()
        {
            Initialize();
            await CallMethod();

            _mockItemManager.Verify(x => x.GetItemAsync(_itemId), Times.Once);
        }

        #endregion

        #region Helpers

        private async Task<Item> CallMethod()
            => await _itemController.Get(_itemId);

        #endregion
    }
}
