using FundManager.Model;
using FundManager.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace FundManager.UnitTests.ViewModels
{
    [TestClass]
    public class FundViewModelTests
    {
        [TestMethod]
        public void EquityTotalNumber_WhenCalled_ReturnsFundEquityStockCount()
        {
            var fund = new Fund();
            fund.AddStock(Constants.EquityStockTypeName, Constants.Price, Constants.Quantity);
            fund.AddStock(Constants.EquityStockTypeName, Constants.Price, Constants.Quantity);

            var fundVm = new FundViewModel(fund);

            Assert.AreEqual(fund.EquityStockCount, fundVm.EquityTotalNumber);
        }

        [TestMethod]
        public void EquityTotalStockWeight_WhenCalled_ReturnsFundTotalEquityStockWeight()
        {
            var fund = new Fund();
            fund.AddStock(Constants.EquityStockTypeName, Constants.Price, Constants.Quantity);
            fund.AddStock(Constants.EquityStockTypeName, Constants.Price, Constants.Quantity);

            var fundVm = new FundViewModel(fund);

            Assert.AreEqual(fund.TotalEquityStockWeight, fundVm.EquityTotalStockWeight);
        }

        [TestMethod]
        public void EquityTotalMarketValue_WhenCalled_ReturnsFundEquitiesTotalMarketValue()
        {
            var fund = new Fund();
            fund.AddStock(Constants.EquityStockTypeName, Constants.Price, Constants.Quantity);
            fund.AddStock(Constants.EquityStockTypeName, Constants.Price, Constants.Quantity);

            var fundVm = new FundViewModel(fund);

            Assert.AreEqual(fund.EquitiesTotalMarketValue, fundVm.EquityTotalMarketValue);
        }

        [TestMethod]
        public void PropertyChanged_GetsRaisedForEquityTotalNumber_WhenStockIsAddedToFund()
        {   
            var fund = new Fund();

            List<string> propertyNames = new List<string>();

            var fundVm = new FundViewModel(fund);
            fundVm.PropertyChanged += (s, e) => propertyNames.Add(e.PropertyName);

            fund.AddStock(Constants.EquityStockTypeName, Constants.Price, Constants.Quantity);
            
            Assert.IsTrue(propertyNames.Any(s => s.Equals("EquityTotalNumber")), "PropertyChanged must be raised for EquityTotalNumber");
        }

        [TestMethod]
        public void PropertyChanged_GetsRaisedForEquityTotalMarketValue_WhenStockIsAddedToFund()
        {
            var fund = new Fund();

            List<string> propertyNames = new List<string>();

            var fundVm = new FundViewModel(fund);
            fundVm.PropertyChanged += (s, e) => propertyNames.Add(e.PropertyName);

            fund.AddStock(Constants.EquityStockTypeName, Constants.Price, Constants.Quantity);

            Assert.IsTrue(propertyNames.Any(s => s.Equals("EquityTotalMarketValue")), "PropertyChanged must be raised for EquityTotalMarketValue");
        }

        [TestMethod]
        public void PropertyChanged_GetsRaisedForEquityTotalStockWeight_WhenStockIsAddedToFund()
        {
            var fund = new Fund();

            List<string> propertyNames = new List<string>();

            var fundVm = new FundViewModel(fund);
            fundVm.PropertyChanged += (s, e) => propertyNames.Add(e.PropertyName);

            fund.AddStock(Constants.EquityStockTypeName, Constants.Price, Constants.Quantity);

            Assert.IsTrue(propertyNames.Any(s => s.Equals("EquityTotalStockWeight")), "PropertyChanged must be raised for EquityTotalStockWeight");
        }

        [TestMethod]
        public void BondTotalNumber_WhenCalled_ReturnsFundBondStockCount()
        {
            var fund = new Fund();
            fund.AddStock(Constants.BondStockTypeName, Constants.Price, Constants.Quantity);
            fund.AddStock(Constants.BondStockTypeName, Constants.Price, Constants.Quantity);

            var fundVm = new FundViewModel(fund);

            Assert.AreEqual(fund.BondStockCount, fundVm.BondTotalNumber);
        }

        [TestMethod]
        public void BondTotalStockWeight_WhenCalled_ReturnsFundTotalBondStockWeight()
        {
            var fund = new Fund();
            fund.AddStock(Constants.BondStockTypeName, Constants.Price, Constants.Quantity);
            fund.AddStock(Constants.BondStockTypeName, Constants.Price, Constants.Quantity);

            var fundVm = new FundViewModel(fund);

            Assert.AreEqual(fund.TotalBondStockWeight, fundVm.BondTotalStockWeight);
        }

        [TestMethod]
        public void BondTotalMarketValue_WhenCalled_ReturnsFundBondTotalMarketValue()
        {
            var fund = new Fund();
            fund.AddStock(Constants.BondStockTypeName, Constants.Price, Constants.Quantity);
            fund.AddStock(Constants.BondStockTypeName, Constants.Price, Constants.Quantity);

            var fundVm = new FundViewModel(fund);

            Assert.AreEqual(fund.BondsTotalMarketValue, fundVm.BondTotalMarketValue);
        }

        [TestMethod]
        public void PropertyChanged_GetsRaisedForBondTotalNumber_WhenStockIsAddedToFund()
        {
            var fund = new Fund();

            List<string> propertyNames = new List<string>();

            var fundVm = new FundViewModel(fund);
            fundVm.PropertyChanged += (s, e) => propertyNames.Add(e.PropertyName);

            fund.AddStock(Constants.BondStockTypeName, Constants.Price, Constants.Quantity);

            Assert.IsTrue(propertyNames.Any(s => s.Equals("BondTotalNumber")), "PropertyChanged must be raised for BondTotalNumber");
        }

        [TestMethod]
        public void PropertyChanged_GetsRaisedForBondTotalMarketValue_WhenStockIsAddedToFund()
        {
            var fund = new Fund();

            List<string> propertyNames = new List<string>();

            var fundVm = new FundViewModel(fund);
            fundVm.PropertyChanged += (s, e) => propertyNames.Add(e.PropertyName);

            fund.AddStock(Constants.BondStockTypeName, Constants.Price, Constants.Quantity);

            Assert.IsTrue(propertyNames.Any(s => s.Equals("BondTotalMarketValue")), "PropertyChanged must be raised for BondTotalMarketValue");
        }

        [TestMethod]
        public void PropertyChanged_GetsRaisedForBondTotalStockWeight_WhenStockIsAddedToFund()
        {
            var fund = new Fund();

            List<string> propertyNames = new List<string>();

            var fundVm = new FundViewModel(fund);
            fundVm.PropertyChanged += (s, e) => propertyNames.Add(e.PropertyName);

            fund.AddStock(Constants.BondStockTypeName, Constants.Price, Constants.Quantity);

            Assert.IsTrue(propertyNames.Any(s => s.Equals("BondTotalStockWeight")), "PropertyChanged must be raised for BondTotalStockWeight");
        }

        [TestMethod]
        public void StockTotalNumber_WhenCalled_ReturnsFundStockCount()
        {
            var fund = new Fund();
            fund.AddStock(Constants.BondStockTypeName, Constants.Price, Constants.Quantity);
            fund.AddStock(Constants.EquityStockTypeName, Constants.Price, Constants.Quantity);

            var fundVm = new FundViewModel(fund);

            Assert.AreEqual(fund.Stocks.Count, fundVm.StockTotalNumber);
        }

        [TestMethod]
        public void StockTotalStockWeight_WhenCalled_ReturnsFundTotalBondStockWeight()
        {
            var fund = new Fund();
            fund.AddStock(Constants.EquityStockTypeName, Constants.Price, Constants.Quantity);
            fund.AddStock(Constants.BondStockTypeName, Constants.Price, Constants.Quantity);

            var fundVm = new FundViewModel(fund);

            Assert.AreEqual(fund.TotalStockWeight, fundVm.StockTotalStockWeight);
        }

        [TestMethod]
        public void StockTotalMarketValue_WhenCalled_ReturnsFundStockTotalMarketValue()
        {
            var fund = new Fund();
            fund.AddStock(Constants.BondStockTypeName, Constants.Price, Constants.Quantity);
            fund.AddStock(Constants.BondStockTypeName, Constants.Price, Constants.Quantity);

            var fundVm = new FundViewModel(fund);

            Assert.AreEqual(fund.TotalMarketValue, fundVm.StockTotalMarketValue);
        }

        [TestMethod]
        public void PropertyChanged_GetsRaisedForStockTotalNumber_WhenStockIsAddedToFund()
        {
            var fund = new Fund();

            List<string> propertyNames = new List<string>();

            var fundVm = new FundViewModel(fund);
            fundVm.PropertyChanged += (s, e) => propertyNames.Add(e.PropertyName);

            fund.AddStock(Constants.BondStockTypeName, Constants.Price, Constants.Quantity);

            Assert.IsTrue(propertyNames.Any(s => s.Equals("StockTotalNumber")), "PropertyChanged must be raised for StockTotalNumber");
        }

        [TestMethod]
        public void PropertyChanged_GetsRaisedForStockTotalMarketValue_WhenStockIsAddedToFund()
        {
            var fund = new Fund();

            List<string> propertyNames = new List<string>();

            var fundVm = new FundViewModel(fund);
            fundVm.PropertyChanged += (s, e) => propertyNames.Add(e.PropertyName);

            fund.AddStock(Constants.BondStockTypeName, Constants.Price, Constants.Quantity);

            Assert.IsTrue(propertyNames.Any(s => s.Equals("StockTotalMarketValue")), "PropertyChanged must be raised for StockTotalMarketValue");
        }

        [TestMethod]
        public void PropertyChanged_GetsRaisedForStockTotalStockWeight_WhenStockIsAddedToFund()
        {
            var fund = new Fund();

            List<string> propertyNames = new List<string>();

            var fundVm = new FundViewModel(fund);
            fundVm.PropertyChanged += (s, e) => propertyNames.Add(e.PropertyName);

            fund.AddStock(Constants.BondStockTypeName, Constants.Price, Constants.Quantity);

            Assert.IsTrue(propertyNames.Any(s => s.Equals("StockTotalStockWeight")), "PropertyChanged must be raised for StockTotalStockWeight");
        }
    }
}
