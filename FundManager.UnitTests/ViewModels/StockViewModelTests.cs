using FundManager.Model;
using FundManager.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FundManager.UnitTests.ViewModels
{
    [TestClass]
    public class StockViewModelTests
    {
        [TestMethod]
        public void Name_WhenCalled_ReturnsStockName()
        {
            var equityStock = new EquityStock(Constants.Price, Constants.Quantity);
            var fund = new Fund();

            var stockVm = new StockViewModel(equityStock, fund);

            Assert.AreEqual(equityStock.Name, stockVm.Name);
        }

        [TestMethod]
        public void Price_WhenCalled_ReturnsStockPrice()
        {
            var equityStock = new EquityStock(Constants.Price, Constants.Quantity);
            var fund = new Fund();

            var stockVm = new StockViewModel(equityStock, fund);

            Assert.AreEqual(equityStock.Price, stockVm.Price);
        }

        [TestMethod]
        public void Quantity_WhenCalled_ReturnsStockQuantity()
        {
            var equityStock = new EquityStock(Constants.Price, Constants.Quantity);
            var fund = new Fund();

            var stockVm = new StockViewModel(equityStock, fund);

            Assert.AreEqual(equityStock.Quantity, stockVm.Quantity);
        }

        [TestMethod]
        public void MarketValue_WhenCalled_ReturnsStockMarketValue()
        {
            var equityStock = new EquityStock(Constants.Price, Constants.Quantity);
            var fund = new Fund();

            var stockVm = new StockViewModel(equityStock, fund);

            Assert.AreEqual(equityStock.MarketValue, stockVm.MarketValue);
        }

        [TestMethod]
        public void StockWeight_WhenCalled_ReturnsStockStockWeight()
        {
            var fund = new Fund();
            fund.AddStock(Constants.EquityStockTypeName, Constants.Price, Constants.Quantity);
            var equityStock = fund.Stocks[0];

            var stockVm = new StockViewModel(equityStock, fund);

            Assert.AreEqual(equityStock.CalculateStockWeight(fund.TotalMarketValue), stockVm.StockWeight);
        }

        [TestMethod]
        public void TransactionCost_WhenCalled_ReturnsStockTransactionCost()
        {
            var fund = new Fund();
            fund.AddStock(Constants.EquityStockTypeName, Constants.Price, Constants.Quantity);
            var equityStock = fund.Stocks[0];

            var stockVm = new StockViewModel(equityStock, fund);

            Assert.AreEqual(equityStock.TransactionCost, stockVm.TransactionCost);
        }

        [TestMethod]
        public void StockType_WhenCalled_ReturnsStockType()
        {
            var fund = new Fund();
            fund.AddStock(Constants.EquityStockTypeName, Constants.Price, Constants.Quantity);
            var equityStock = fund.Stocks[0];

            var stockVm = new StockViewModel(equityStock, fund);

            Assert.AreEqual(Constants.Equity, stockVm.StockType);
        }

        [TestMethod]
        public void Highlight_WhenCalledForStockMarketValueLessThanZero_ReturnTrue()
        {
            var equityStock = new EquityStock(-1m, Constants.Quantity);
            var fund = new Fund();

            var stockVm = new StockViewModel(equityStock, fund);

            Assert.IsTrue(stockVm.Highlight);
        }

        [TestMethod]
        public void Highlight_WhenCalledForTransactionCostIsGreaterThanStockTolerance_ReturnTrue()
        {
            var equityStock = new EquityStock(3000000000m, Constants.Quantity);
            var fund = new Fund();

            var stockVm = new StockViewModel(equityStock, fund);

            Assert.IsTrue(stockVm.Highlight);
        }

        [TestMethod]
        public void PropertyChanged_GetsRaisedForStockWeight_WhenStockIsAddedToFund()
        {
            var equityStock = new EquityStock(3000000000m, Constants.Quantity);
            var fund = new Fund();

            string propertyName = string.Empty;

            var stockVm = new StockViewModel(equityStock, fund);
            stockVm.PropertyChanged += (s, e) => propertyName = e.PropertyName;

            fund.AddStock(Constants.EquityStockTypeName, Constants.Price, Constants.Quantity);

            Assert.AreEqual("StockWeight", propertyName);
        }
    }
}
