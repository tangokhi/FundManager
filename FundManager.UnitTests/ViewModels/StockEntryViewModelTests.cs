using FundManager.Service;
using FundManager.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace FundManager.UnitTests.ViewModels
{
    [TestClass]
    public class StockEntryViewModelTests
    {
        [TestMethod]
        public void StockTypes_WhenCalled_ReturnsAvailableStockTypes()
        {
            var mockFundManagerService = new Mock<IFundManagerService>();

            var stockEntryVm = new StockEntryViewModel(mockFundManagerService.Object);

            Assert.IsTrue(stockEntryVm.StockTypes.Any(st => st.Equals(Constants.EquityStockTypeName)), $"StockTypes should contain {Constants.EquityStockTypeName}");

            Assert.IsTrue(stockEntryVm.StockTypes.Any(st => st.Equals(Constants.BondStockTypeName)), $"StockTypes should contain {Constants.BondStockTypeName}");
        }

        [TestMethod]
        public void SaveStockCommand_WhenInvoked_SavesFund()
        {
            var mockFundManagerService = new Mock<IFundManagerService>();
            mockFundManagerService.Setup(s => s.AddStock(Constants.EquityStockTypeName, Constants.Price, Constants.Quantity));
            var stockEntryVm = new StockEntryViewModel(mockFundManagerService.Object);

            stockEntryVm.Price = Constants.Price.ToString();
            stockEntryVm.Quantity = Constants.Quantity.ToString();
            stockEntryVm.StockType = Constants.EquityStockTypeName;

            stockEntryVm.SaveStockCommand.Execute();
            mockFundManagerService.Verify();
        }

        [TestMethod]
        public void SaveStockCommand_WhenInvokedWithAllRequiredValues_CanSave()
        {
            var mockFundManagerService = new Mock<IFundManagerService>();
            mockFundManagerService.Setup(s => s.AddStock(Constants.EquityStockTypeName, Constants.Price, Constants.Quantity));
            var stockEntryVm = new StockEntryViewModel(mockFundManagerService.Object);

            stockEntryVm.Price = Constants.Price.ToString();
            stockEntryVm.Quantity = Constants.Quantity.ToString();
            stockEntryVm.StockType = Constants.EquityStockTypeName;

            Assert.IsTrue(stockEntryVm.SaveStockCommand.CanExecute());
        }

        [TestMethod]
        public void SaveStockCommand_WhenPriceIsNull_CannotSave()
        {
            var mockFundManagerService = new Mock<IFundManagerService>();
            mockFundManagerService.Setup(s => s.AddStock(Constants.EquityStockTypeName, Constants.Price, Constants.Quantity));
            var stockEntryVm = new StockEntryViewModel(mockFundManagerService.Object);

            stockEntryVm.Price = null;
            stockEntryVm.Quantity = Constants.Quantity.ToString();
            stockEntryVm.StockType = Constants.EquityStockTypeName;

            Assert.IsFalse(stockEntryVm.SaveStockCommand.CanExecute());
        }

        [TestMethod]
        public void SaveStockCommand_WhenQuantityIsNull_CannotSave()
        {
            var mockFundManagerService = new Mock<IFundManagerService>();
            mockFundManagerService.Setup(s => s.AddStock(Constants.EquityStockTypeName, Constants.Price, Constants.Quantity));
            var stockEntryVm = new StockEntryViewModel(mockFundManagerService.Object);

            stockEntryVm.Price = Constants.Price.ToString();
            stockEntryVm.Quantity = null;
            stockEntryVm.StockType = Constants.EquityStockTypeName;

            Assert.IsFalse(stockEntryVm.SaveStockCommand.CanExecute());
        }

        [TestMethod]
        public void SaveStockCommand_WhenStockTypeIsNull_CannotSave()
        {
            var mockFundManagerService = new Mock<IFundManagerService>();
            mockFundManagerService.Setup(s => s.AddStock(Constants.EquityStockTypeName, Constants.Price, Constants.Quantity));
            var stockEntryVm = new StockEntryViewModel(mockFundManagerService.Object);

            stockEntryVm.Price = Constants.Price.ToString();
            stockEntryVm.Quantity = Constants.Quantity.ToString();
            stockEntryVm.StockType = null;

            Assert.IsFalse(stockEntryVm.SaveStockCommand.CanExecute());
        }

        [TestMethod]
        public void Price_WhenNull_ResultsInError()
        {
            var mockFundManagerService = new Mock<IFundManagerService>();
            mockFundManagerService.Setup(s => s.AddStock(Constants.EquityStockTypeName, Constants.Price, Constants.Quantity));
            var stockEntryVm = new StockEntryViewModel(mockFundManagerService.Object);

            string error = stockEntryVm["Price"];

            Assert.IsFalse(string.IsNullOrWhiteSpace(error));
        }

        [TestMethod]
        public void Price_WhenNotDecimalValue_ResultsInError()
        {
            var mockFundManagerService = new Mock<IFundManagerService>();
            mockFundManagerService.Setup(s => s.AddStock(Constants.EquityStockTypeName, Constants.Price, Constants.Quantity));
            var stockEntryVm = new StockEntryViewModel(mockFundManagerService.Object);

            stockEntryVm.Price = "abcd";
            string error = stockEntryVm["Price"];

            Assert.IsFalse(string.IsNullOrWhiteSpace(error));
        }

        [TestMethod]
        public void Quantity_WhenNull_ResultsInError()
        {
            var mockFundManagerService = new Mock<IFundManagerService>();
            mockFundManagerService.Setup(s => s.AddStock(Constants.EquityStockTypeName, Constants.Price, Constants.Quantity));
            var stockEntryVm = new StockEntryViewModel(mockFundManagerService.Object);

            string error = stockEntryVm["Quantity"];

            Assert.IsFalse(string.IsNullOrWhiteSpace(error));
        }

        [TestMethod]
        public void Quantity_WhenNotIntegerValue_ResultsInError()
        {
            var mockFundManagerService = new Mock<IFundManagerService>();
            mockFundManagerService.Setup(s => s.AddStock(Constants.EquityStockTypeName, Constants.Price, Constants.Quantity));
            var stockEntryVm = new StockEntryViewModel(mockFundManagerService.Object);

            stockEntryVm.Price = "abcd";
            string error = stockEntryVm["Quantity"];

            Assert.IsFalse(string.IsNullOrWhiteSpace(error));
        }

        [TestMethod]
        public void StockType_WhenNull_ResultsInError()
        {
            var mockFundManagerService = new Mock<IFundManagerService>();
            mockFundManagerService.Setup(s => s.AddStock(Constants.EquityStockTypeName, Constants.Price, Constants.Quantity));
            var stockEntryVm = new StockEntryViewModel(mockFundManagerService.Object);

            string error = stockEntryVm["StockType"];

            Assert.IsFalse(string.IsNullOrWhiteSpace(error));
        }
    }
}
