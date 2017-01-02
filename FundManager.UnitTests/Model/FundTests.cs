using FundManager.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace FundManager.UnitTests.Model
{
    [TestClass]
    public class FundTests
    {
        [TestMethod]
        public void AddStock_WhenCalled_AddStocksSuccessfully()
        {
            var fund = new Fund();
            fund.AddStock(typeof(EquityStock).Name, Constants.Price, Constants.Quantity);
            fund.AddStock(typeof(BondStock).Name, Constants.Price, Constants.Quantity);

            var equityStocks = fund.Stocks.Where(s => s is EquityStock);
            Assert.AreEqual(1, equityStocks.Count());

            EquityStock equityStock = equityStocks.First() as EquityStock;

            Assert.AreEqual(Constants.Price, equityStock.Price);
            Assert.AreEqual(Constants.Quantity, equityStock.Quantity);
            Assert.AreEqual("Equity1", equityStock.Name);

            var bondStocks = fund.Stocks.Where(s => s is BondStock);
            Assert.AreEqual(1, bondStocks.Count());

            BondStock bondStock = bondStocks.First() as BondStock;
            
            Assert.AreEqual("Bond1", bondStock.Name);
        }

        [TestMethod]
        public void AddStock_WhenCalled_AddStocksWithCorrectNames()
        {
            var fund = new Fund();
            fund.AddStock(typeof(BondStock).Name, Constants.Price, Constants.Quantity);
            fund.AddStock(typeof(BondStock).Name, Constants.Price, Constants.Quantity);
            
            var bondStocks = fund.Stocks.Where(s => s is BondStock).ToList();
            Assert.AreEqual(2, bondStocks.Count);

           
            for (int loop = 0; loop < 2; loop++)
            {
                Assert.AreEqual($"Bond{loop + 1}", bondStocks[loop].Name);
            }
        }

        [TestMethod]
        public void AddStock_WhenCalled_RaisesAddStockEvent()
        {
            EquityStock equityStock = null;
            var fund = new Fund();

            fund.AddStockEvent += (s, args) =>
            {
                equityStock = args.Data as EquityStock;
            };

            fund.AddStock(typeof(EquityStock).Name, Constants.Price, Constants.Quantity);

            Assert.IsNotNull(equityStock);
        }

        [TestMethod]
        public void EquityStockCount_WhenCalled_ReturnsCorrectValue()
        {
            var fund = new Fund();
            fund.AddStock(typeof(BondStock).Name, Constants.Price, Constants.Quantity);
            fund.AddStock(typeof(EquityStock).Name, Constants.Price, Constants.Quantity);
            fund.AddStock(typeof(EquityStock).Name, Constants.Price, Constants.Quantity);

            Assert.AreEqual(2, fund.EquityStockCount);
        }

        [TestMethod]
        public void BondStockCount_WhenCalled_ReturnsCorrectValue()
        {
            var fund = new Fund();
            fund.AddStock(typeof(BondStock).Name, Constants.Price, Constants.Quantity);
            fund.AddStock(typeof(BondStock).Name, Constants.Price, Constants.Quantity);

            Assert.AreEqual(2, fund.BondStockCount);
        }

        [TestMethod]
        public void EquitiesTotalMarketValue_WhenCalled_ReturnsSumOfEquitiesMarketValue()
        {
            var fund = new Fund();
            fund.AddStock(typeof(EquityStock).Name, Constants.Price, Constants.Quantity);
            fund.AddStock(typeof(EquityStock).Name, Constants.Price, Constants.Quantity);

            decimal expectedEquitiesTotalMarketValue = 2 * (Constants.Price * Constants.Quantity);

            Assert.AreEqual(expectedEquitiesTotalMarketValue, fund.EquitiesTotalMarketValue);
        }

        [TestMethod]
        public void BondsTotalMarketValue_WhenCalled_ReturnsSumOfEquitiesMarketValue()
        {
            var fund = new Fund();
            fund.AddStock(typeof(BondStock).Name, Constants.Price, Constants.Quantity);
            fund.AddStock(typeof(BondStock).Name, Constants.Price, Constants.Quantity);

            decimal expectedBondsTotalMarketValue = 2 * (Constants.Price * Constants.Quantity);

            Assert.AreEqual(expectedBondsTotalMarketValue, fund.BondsTotalMarketValue);
        }

        [TestMethod]
        public void TotalEquityStockWeight_WhenCalled_ReturnsCorrectValue()
        {
            var fund = new Fund();
            fund.AddStock(typeof(BondStock).Name, Constants.Price, Constants.Quantity);
            fund.AddStock(typeof(EquityStock).Name, Constants.Price, Constants.Quantity);

            decimal expectedEquityStockWeight = ((Constants.Price * Constants.Quantity) * fund.TotalMarketValue) / 100;

            Assert.AreEqual(expectedEquityStockWeight, fund.TotalEquityStockWeight);
        }

        [TestMethod]
        public void TotalBondStockWeight_WhenCalled_ReturnsCorrectValue()
        {
            var fund = new Fund();
            fund.AddStock(typeof(BondStock).Name, Constants.Price, Constants.Quantity);
            fund.AddStock(typeof(EquityStock).Name, Constants.Price, Constants.Quantity);

            decimal expectedBondStockWeight = ((Constants.Price * Constants.Quantity) * fund.TotalMarketValue) / 100;

            Assert.AreEqual(expectedBondStockWeight, fund.TotalBondStockWeight);
        }

        [TestMethod]
        public void TotalStockWeight_WhenCalled_ReturnsCorrectValue()
        {
            var fund = new Fund();
            fund.AddStock(typeof(BondStock).Name, Constants.Price, Constants.Quantity);
            fund.AddStock(typeof(EquityStock).Name, Constants.Price, Constants.Quantity);

            decimal expectedTotalStockWeight = 2 * (((Constants.Price * Constants.Quantity) * fund.TotalMarketValue) / 100);

            Assert.AreEqual(expectedTotalStockWeight, fund.TotalStockWeight);
        }
    }
}
