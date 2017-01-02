using FundManager.Model;
using FundManager.Repository;
using FundManager.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FundManager.UnitTests.Service
{
    [TestClass]
    public class FundManagerServiceTest
    {
        [TestMethod]
        public void AddStock_WhenCalled_AddStockToTheFund()
        {
            var fund = new Fund();
            var mockFundRepository = new Mock<IFundRepository>();
            mockFundRepository.Setup(r => r.GetFund()).Returns(fund);

            var service = new FundManagerService(mockFundRepository.Object);

            service.AddStock(Constants.EquityStockTypeName, Constants.Price, Constants.Quantity);

            Assert.AreEqual(1, fund.EquityStockCount);
        }
    }
}
