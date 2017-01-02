using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FundManager.Service;
using FundManager.Model;
using FundManager.ViewModels;

namespace FundManager.UnitTests.ViewModels
{
    [TestClass]
    public class StockCollectionViewModelTests
    {
        [TestMethod]
        public void Stocks_WhenCalled_ReturnsStockInFund()
        {
            var mockFundServiceManager = new Mock<IFundManagerService>();

            var fund = new Fund();
            fund.AddStock(Constants.BondStockTypeName, Constants.Price, Constants.Quantity);

            mockFundServiceManager.Setup(s => s.GetFund()).Returns(fund);

            var stockCollectionVm = new StockCollectionViewModel(mockFundServiceManager.Object);

            Assert.AreEqual(fund.Stocks.Count, stockCollectionVm.Stocks.Count);
        }

        [TestMethod]
        public void Stocks_WhenAddedToFund_ReturnsStockInFund()
        {
            var mockFundServiceManager = new Mock<IFundManagerService>();

            var fund = new Fund();
            
            mockFundServiceManager.Setup(s => s.GetFund()).Returns(fund);

            var stockCollectionVm = new StockCollectionViewModel(mockFundServiceManager.Object);

            Assert.AreEqual(0, stockCollectionVm.Stocks.Count);

            fund.AddStock(Constants.BondStockTypeName, Constants.Price, Constants.Quantity);
            Assert.AreEqual(1, stockCollectionVm.Stocks.Count);
        }
    }
}
