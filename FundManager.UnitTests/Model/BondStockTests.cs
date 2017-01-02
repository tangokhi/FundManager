using FundManager.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FundManager.UnitTests.Model
{
    [TestClass]
    public class BondStockTests
    {
        [TestMethod]
        public void MarketValue_WhenCalled_CalculatesValueCorrectly()
        {
            var bondStock = new BondStock(Constants.Price, Constants.Quantity);

            decimal marketValue = Constants.Price * Constants.Quantity;

            Assert.AreEqual(marketValue, bondStock.MarketValue);
        }

        [TestMethod]
        public void TransactionCost_WhenCalled_CalculatesValueCorrectly()
        {
            var bondStock = new BondStock(Constants.Price, Constants.Quantity);

            decimal expectedTransactionCost = bondStock.MarketValue * (2m / 100);

            Assert.AreEqual(expectedTransactionCost, bondStock.TransactionCost);
        }

        [TestMethod]
        public void Tolerance_WhenCalled_ReturnsCorrectValue()
        {
            var bondStock = new BondStock(Constants.Price, Constants.Quantity);

            Assert.AreEqual(100000, bondStock.Tolerance);
        }

        [TestMethod]
        public void CalculateStockWeight_WhenCalled_CalculatesValueCorrectly()
        {
            const decimal fundMarketValue = 10m;

            var bondStock = new BondStock(Constants.Price, Constants.Quantity);

            decimal expectedStockWeight = (bondStock.MarketValue * fundMarketValue) / 100;

            Assert.AreEqual(expectedStockWeight, bondStock.CalculateStockWeight(fundMarketValue));
        }

        [TestMethod]
        public void StockType_WhenCalled_ReturnsCorrectValue()
        {
            var bondStock = new BondStock(Constants.Price, Constants.Quantity);

            Assert.AreEqual(Constants.Bond, bondStock.StockType);
        }
    }
}
