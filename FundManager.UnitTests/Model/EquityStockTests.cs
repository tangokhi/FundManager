using FundManager.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FundManager.UnitTests.Model
{
    [TestClass]
    public class EquityStockTests
    { 
        [TestMethod]
        public void MarketValue_WhenCalled_CalculatesValueCorrectly()
        {
            var equityStock = new EquityStock(Constants.Price, Constants.Quantity);

            decimal marketValue = Constants.Price * Constants.Quantity;

            Assert.AreEqual(marketValue, equityStock.MarketValue);
        }

        [TestMethod]
        public void TransactionCost_WhenCalled_CalculatesValueCorrectly()
        {
            var equityStock = new EquityStock(Constants.Price, Constants.Quantity);

            decimal expectedTransactionCost = equityStock.MarketValue * (0.5m / 100);

            Assert.AreEqual(expectedTransactionCost, equityStock.TransactionCost);
        }

        [TestMethod]
        public void Tolerance_WhenCalled_ReturnsCorrectValue()
        {
            var equityStock = new EquityStock(Constants.Price, Constants.Quantity);

            Assert.AreEqual(200000, equityStock.Tolerance);
        }

        [TestMethod]
        public void CalculateStockWeight_WhenCalled_CalculatesValueCorrectly()
        {
            const decimal fundMarketValue = 10m;

            var equityStock = new EquityStock(Constants.Price, Constants.Quantity);

            decimal expectedStockWeight = (equityStock.MarketValue * fundMarketValue) / 100;

            Assert.AreEqual(expectedStockWeight, equityStock.CalculateStockWeight(fundMarketValue));
        }

        [TestMethod]
        public void StockType_WhenCalled_ReturnsCorrectValue()
        {
            var equityStock = new EquityStock(Constants.Price, Constants.Quantity);

            Assert.AreEqual(Constants.Equity, equityStock.StockType);
        }
    }
}
